namespace PalpatineApi.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class PalpatineData : DbContext
	{
		public PalpatineData()
			: base("name=PalpatineData")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<UserData> UserData { get; set; }
		public DbSet<Gallery> Gallery { get; set; }
		public DbSet<Image> Image { get; set; }
		public DbSet<Tag> Tag { get; set; }
	}
}
