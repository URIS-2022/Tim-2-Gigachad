using Microsoft.EntityFrameworkCore;

namespace DokumentiService.Entities
{
    public class DokumentContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public DokumentContext(DbContextOptions options) : base(options) { }

        public DbSet<DokumentEntity> Dokumenti { get; set; }
        public DbSet<EksterniDokumentEntity> EksterniDokumenti { get; set; }
        public DbSet<InterniDokumentEntity> InterniDokumenti { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EksterniDokumentEntity>().HasData(new
            {
                EksterniDokumentID = Guid.Parse("475b61f1-dccd-404a-a657-43fb9ec729ce"),
                PutanjaDokumenta = "Ovo je samo da vidimo sta ce da pise"
            });
            builder.Entity<EksterniDokumentEntity>().HasData(new
            {
                EksterniDokumentID = Guid.Parse("72922197-afd8-49ad-877b-6573b7d50714"),
                PutanjaDokumenta = "Ovo je nesto nesto da vidimo sta ce da pise drugi deo brapoooo"
                
            });
        }
    }
}