using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
    using System.IO;

    internal class DirectoryScanner : IProgress
    {
        private readonly string path;
        private readonly object syncLock = new object();

        private List<DataFile> files;

        private int _current;
        private int _total;

        public int Value
        {
            get
            {
                if (_total == 0) return 0;
                decimal current = _current;
                decimal total = _total;
                return Convert.ToInt32(current / total * 100);
            }
        }

        public DirectoryScanner(string path)
        {
            this.path = path;
            this.files = new List<DataFile>();
        }

        public async Task<Guid> ScanAsync()
        {
            return await Task.Run(() => Scan());
        }

        public Guid Scan()
        {
            var searchedFiles = Directory.EnumerateFiles(this.path, "*.*", SearchOption.AllDirectories);

            var scanId = Guid.NewGuid();

            foreach (var file in searchedFiles)
            {
                if (FileShouldBeExcluded(file)) continue;
                var info = new FileInfo(file);
                this.files.Add(new DataFile { ScanId = scanId, FileNameFull = file, Size = info.Length });
            }
            _total = this.files.Count();

            using (var context = new DatabaseContext())
            {
                var skip = 0;
                var toSave = this.files.Take(100);
                while (toSave != null && toSave.Count() > 0)
                {
                    context.SearchFiles.AddRange(toSave);
                    context.SaveChanges();
                    skip = skip + 100;
                    _current = _current + 100;
                    toSave = this.files.Skip(skip).Take(100);
                }
            }

            return scanId;
        }

        public async Task<Guid> HashAsync(Guid scanId)
        {
            return await Task.Run(() => Hash(scanId));
        }

        public Guid Hash(Guid scanId)
        {
            _current = 0;
            using (var context = new DatabaseContext())
            {
                var allUnHashedfiles = context.SearchFiles.Where(item => item.ScanId == scanId && string.IsNullOrEmpty(item.Hash)).OrderBy(ord => ord.Size);
                _total = allUnHashedfiles.Count();

                var skip = 0;
                var toSave = allUnHashedfiles.Take(100);
                while (toSave != null && toSave.Count() > 0)
                {
                    Parallel.ForEach(toSave, (file) =>
                    {
                        var hash = FileHashCreator.GetMD5Hash(file.FileNameFull);
                        file.Hash = hash;
                        _current++;
                    });
                    context.SaveChanges();
                    skip = skip + 100;
                    toSave = allUnHashedfiles.Skip(skip).Take(100);
                }
            }

            return scanId;
        }

        public static Guid LastScanId()
        {
            using (var context = new DatabaseContext())
            {
                return context.SearchFiles.OrderByDescending(item => item.Id).First().ScanId;
            }
        }

        private static bool FileShouldBeExcluded(string filename)
        {
            return (Path.GetFileName(filename).Equals("Thumbs.db", StringComparison.OrdinalIgnoreCase))
                || (Path.GetExtension(filename).Equals(".zip", StringComparison.OrdinalIgnoreCase)
                || (Path.GetExtension(filename).Equals(".MPG", StringComparison.OrdinalIgnoreCase)));
        }
    }
}
