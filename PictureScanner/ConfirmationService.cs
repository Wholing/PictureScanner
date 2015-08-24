using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
	internal class ConfirmationService
	{
		private readonly Guid scanId;

		public ConfirmationService(Guid scanId)
		{
			this.scanId = scanId;
		}

		public ComparisonPair NextComparison()
		{
			using (var context = new DatabaseContext())
			{
				var dup = context.DuplicateFiles.Include("Datafile").FirstOrDefault(item => item.ScanId == this.scanId && !item.Confirmed && !item.NotDuplicate);
				if (dup == null) return null;
				var toFind = context.DuplicationOwners.Include("Owner").FirstOrDefault(owner => owner.DuplicateFiles.Any(suspect => suspect.DataFile.Id == dup.DataFileId));
				return new ComparisonPair(toFind, dup);
			}
		}

		public void Confirm(ComparisonPair currentComparison)
		{
			using (var context = new DatabaseContext())
			{
				var item = context.DuplicateFiles.Find(currentComparison.DuplicateFile.Id);
				item.Confirmed = true;
				context.SaveChanges();
			}
		}

		public void Deny(ComparisonPair currentComparison)
		{
			using (var context = new DatabaseContext())
			{
				var item = context.DuplicateFiles.Find(currentComparison.DuplicateFile.Id);
				item.NotDuplicate = true;
				context.SaveChanges();
			}
		}
	}
}
