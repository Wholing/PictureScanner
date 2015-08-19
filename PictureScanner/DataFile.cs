namespace PictureScanner
{
	using System;
	using System.IO;

	internal class DataFile
	{

		public int Id { get; set; }

		public Guid ScanId { get; set; }

		public string FileNameFull { get; set; }

		public long Size { get; set; }
	}
}