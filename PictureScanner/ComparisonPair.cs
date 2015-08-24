namespace PictureScanner
{
	internal class ComparisonPair
	{
		public ComparisonPair(DuplicationOwner owner, DuplicateFile duplicateFile)
		{
			this.Owner = owner;
			this.DuplicateFile = duplicateFile;
		}

		public DuplicationOwner Owner { get; set; }

		public DuplicateFile DuplicateFile { get; set; }
	}
}