using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
	using System.Data.Entity;

	internal class DatabaseContext : DbContext
	{
		public DbSet<DataFile> SearchFiles { get; set; }

		public DbSet<DuplicationOwner> DuplicationOwners { get; set; } 

		public DbSet<DuplicateFile> DuplicateFiles { get; set; } 
	}
}
