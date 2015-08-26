namespace PictureScanner
{
	using System;
	using System.ComponentModel.DataAnnotations;

	internal class DataFile
	{

		[Key]
		public int Id { get; set; }

		public Guid ScanId { get; set; }

		public string FileNameFull { get; set; }

		public long Size { get; set; }

        public string Hash { get; set; }
	}
}