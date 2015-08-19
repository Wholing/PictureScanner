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
	}
}
