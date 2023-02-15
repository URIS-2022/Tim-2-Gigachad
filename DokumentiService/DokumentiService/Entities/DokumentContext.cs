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
            builder.Entity<InterniDokumentEntity>().HasData(new
            {
                InterniDokumentID = Guid.Parse("858930f0-92ec-4975-b697-0c7afb2842de"),
                PutanjaDokumenta = "Internal man"

            });
            builder.Entity<InterniDokumentEntity>().HasData(new
            {
                InterniDokumentID = Guid.Parse("9813acc5-35f5-4d3b-886c-42a6aaf162b9"),
                PutanjaDokumenta = "Internal bratskciiii"

            });
            builder.Entity<DokumentEntity>().HasData(new
            {
                DokumentID = Guid.Parse("c9c1ccd3-e953-490e-b69c-cf903d8758f9"),
                EksterniDokumentID = Guid.Parse("d9157fc9-0fde-42db-b44f-98bdc39c8997"),
                InterniDokumentID = Guid.Parse("393dd1ca-ee17-42c7-aaac-6e560a45dfdd"),
                DatumDonosenja = new DateTime(2000,09,20),
                Sablon = 5,
                StatusDokumenta = 4

            });
            builder.Entity<DokumentEntity>().HasData(new
            {
                DokumentID = Guid.Parse("378ffff9-f997-4b7f-8c6e-c674918ef2e9"),
                EksterniDokumentID = Guid.Parse("3d0478c3-6220-4f6b-9438-b5e7fde84b02"),
                InterniDokumentID = Guid.Parse("7a8ef4cd-94f1-4dc8-bf89-9eb17374662b"),
                DatumDonosenja = new DateTime(2000, 09, 20),
                Sablon = 5,
                StatusDokumenta = 4

            });


        }
    }
}