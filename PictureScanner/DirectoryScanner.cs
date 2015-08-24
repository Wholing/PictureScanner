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
				var info = new FileInfo(file);
				this.files.Add(new DataFile { ScanId = scanId, FileNameFull = file, Size = info.Length });
			}

			using (var context = new DatabaseContext())
			{
				context.SearchFiles.AddRange(this.files);
				context.SaveChanges();
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

	}
}
