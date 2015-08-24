namespace PictureScanner
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.IO;

	internal class DataFile
	{

		[Key]
		public int Id { get; set; }

		public Guid ScanId { get; set; }

		public string FileNameFull { get; set; }

		public long Size { get; set; }
	}
}