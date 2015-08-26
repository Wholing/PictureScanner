using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
    using System.IO;

    internal class DirectoryScanner
    {
        private readonly string path;

        private List<DataFile> files;
        public DirectoryScanner(string path)
        {
            this.path = path;
            this.files = new List<DataFile>();
        }

        public Guid Scan()
        {
            var searchedFiles = Directory.EnumerateFiles(this.path, "*.*", SearchOption.AllDirectories);

            var scanId = Guid.NewGuid();

            foreach (var file in searchedFiles)
            {
                if (FileShouldBeExcluded(file)) continue;
                var info = new FileInfo(file);
                var hash = FileHashCreator.GetMD5Hash(file);
                this.files.Add(new DataFile { ScanId = scanId, FileNameFull = file, Size = info.Length, Hash = hash });
            }

            using (var context = new DatabaseContext())
            {
                var skip = 0;
                var toSave = this.files.Take(100);
                while (toSave != null && toSave.Count() > 0)
                {
                    context.SearchFiles.AddRange(toSave);
                    context.SaveChanges();
                    skip = skip + 100;
                    toSave = this.files.Skip(skip).Take(100);
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
