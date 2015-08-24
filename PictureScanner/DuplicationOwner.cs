namespace PictureScanner
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	internal class DuplicationOwner
	{
		public DuplicationOwner()
		{
			this.DuplicateFiles = new List<DuplicateFile>();
		}

		[Key]
		public int Id { get; set; }

		public Guid ScanId { get; set; }

		public int OwnerId { get; set; }
		public DataFile Owner { get; set; }

		public List<DuplicateFile> DuplicateFiles { get; set; }
	}
}