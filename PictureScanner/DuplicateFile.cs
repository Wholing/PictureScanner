namespace PictureScanner
{
	using System;
	using System.ComponentModel.DataAnnotations;

	internal class DuplicateFile
	{
		[Key]
		public int Id { get; set; }
		public Guid ScanId { get; set; }
		public int DataFileId { get; set; }
		public DataFile DataFile { get; set; }
		public bool Confirmed { get; set; }
		public bool NotDuplicate { get; set; }

		public bool NeedsConfirmation => !this.Confirmed && !this.NotDuplicate;
	}
}