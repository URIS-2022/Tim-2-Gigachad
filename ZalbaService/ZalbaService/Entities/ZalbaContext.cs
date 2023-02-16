using Microsoft.EntityFrameworkCore;

namespace ZalbaService.Entities
{
    /// <summary>
    /// DbContext za ZalbaService mikroservis.
    /// </summary>
    public class ZalbaContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public ZalbaContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet za entitet žalba.
        /// </summary>
        public DbSet<ZalbaEntity> Zalbe { get; set; }

        /// <summary>
		/// Popunjava bazu sa nekim inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ZalbaEntity>().HasData(new
            {
                ZalbaID = Guid.Parse("08635d18-5f72-4050-8e5e-c520562675b1"),
                KupacID = Guid.Parse("fb046e3b-a95c-4079-9898-9e16d653d9a3"),
                TipZalbe = "Zalba na tok javnog nadmetanaja",
                DatumPodnosenja = new DateTime(2022, 12, 12),
                Razlog = "Neki razlog",
                Obrazlozenje = "Neko obrazlozenje",
                StatusZalbe = "Usvojena",
                RadnjaZalbe = "JN ide u drugi krug sa novim uslovima"
            });
            builder.Entity<ZalbaEntity>().HasData(new
            {
                ZalbaID = Guid.Parse("9014d78d-7b9b-4f63-b674-d83ed1d5356a"),
                KupacID = Guid.Parse("6f356c53-1dfb-48fa-93a1-18577d5db2b6"),
                TipZalbe = "Zalba na Odluku o davanju nakoriscenje",
                DatumPodnosenja = new DateTime(2021, 11, 11),
                Razlog = "Neki drugi razlog",
                Obrazlozenje = "Neko drugo obrazlozenje",
                StatusZalbe = "Otvorena",
                RadnjaZalbe = "JN ide u drugi krug sa starim uslovima"
            });
        }

    }
}
