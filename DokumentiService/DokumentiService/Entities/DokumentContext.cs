using Microsoft.EntityFrameworkCore;

namespace DokumentiService.Entities
{
    /// <summary>
    /// DB context za DokumentService
    /// </summary>
    public class DokumentContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public DokumentContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet za eksterni Dokument
        /// </summary>
        public DbSet<EksterniDokumentEntity> EksterniDokumenti { get; set; }
        /// <summary>
        /// DbSet za interni dokument
        /// </summary>
        public DbSet<InterniDokumentEntity> InterniDokumenti { get; set; }

        /// <summary>
        /// DbSet za dokument
        /// </summary>
        public DbSet<DokumentEntity> Dokumenti { get; set; }
     

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<EksterniDokumentEntity>().HasData(new
            {
                EksterniDokumentID = Guid.Parse("475b61f1-dccd-404a-a657-43fb9ec729ce"),
                PutanjaDokumenta = "Ovo je samo da vidimo sta ce da pise"
            });
            modelBuilder.Entity<EksterniDokumentEntity>().HasData(new
            {
                EksterniDokumentID = Guid.Parse("72922197-afd8-49ad-877b-6573b7d50714"),
                PutanjaDokumenta = "Ovo je nesto nesto da vidimo sta ce da pise drugi deo brapoooo"
                
            });
            modelBuilder.Entity<InterniDokumentEntity>().HasData(new
            {
                InterniDokumentID = Guid.Parse("858930f0-92ec-4975-b697-0c7afb2842de"),
                PutanjaDokumenta = "Internal man"

            });
            modelBuilder.Entity<InterniDokumentEntity>().HasData(new
            {
                InterniDokumentID = Guid.Parse("9813acc5-35f5-4d3b-886c-42a6aaf162b9"),
                PutanjaDokumenta = "Internal bratskciiii"

            });
            modelBuilder.Entity<DokumentEntity>().HasData(new
            {
                DokumentID = Guid.Parse("c9c1ccd3-e953-490e-b69c-cf903d8758f9"),
                EksterniDokumentID = Guid.Parse("475b61f1-dccd-404a-a657-43fb9ec729ce"),
                InterniDokumentID = Guid.Parse("858930f0-92ec-4975-b697-0c7afb2842de"),
                DatumDonosenja = new DateTime(2000,09,20),
                Sablon = 5,
                StatusDokumenta = 4

            });
            modelBuilder.Entity<DokumentEntity>().HasData(new
            {
                DokumentID = Guid.Parse("378ffff9-f997-4b7f-8c6e-c674918ef2e9"),
                EksterniDokumentID = Guid.Parse("72922197-afd8-49ad-877b-6573b7d50714"),
                InterniDokumentID = Guid.Parse("9813acc5-35f5-4d3b-886c-42a6aaf162b9"),
                DatumDonosenja = new DateTime(2000, 09, 20),
                Sablon = 5,
                StatusDokumenta = 4

            });


        }
    }
}