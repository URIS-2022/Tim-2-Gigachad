using Microsoft.EntityFrameworkCore;

namespace AdresaService.Entities
{
    /// <summary>
	/// DbContext za AdresaService mikroservis.
	/// </summary>
    public class AdresaContext : DbContext
    {
        /// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public AdresaContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet za entitet adresa.
        /// </summary>
        public DbSet<AdresaEntity> Adresa { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Ulica = "Slavoja Perica",
                Broj = 11,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                Ulica = "Dositejeva",
                Broj = 23,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("878100df-6973-4292-acb1-0c25b7ac2260"),
                Ulica = "Jevrejska",
                Broj = 7,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("accad5a2-e5bc-4ff5-a5b7-fc38ab8a47fe"),
                Ulica = "Mise Dimitrijevica",
                Broj = 22,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("cbc77973-6f66-47b5-8b00-bdd9a2ab3650"),
                Ulica = "Brace Kovac",
                Broj = 16,
                Mesto = "Beograd",
                PostanskiBroj = 101801,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("e27e0caf-7d2b-4857-99de-71b63b503ae0"),
                Ulica = "Cerska",
                Broj = 45,
                Mesto = "Beograd",
                PostanskiBroj = 101801,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("d84c6e01-ea38-4d2d-b6d3-ca8eb0766c1e"),
                Ulica = "Dalmatinska",
                Broj = 48,
                Mesto = "Beograd",
                PostanskiBroj = 116468,
                Drzava = "Srbija"
            }); 
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("f94d04c3-0af9-4753-a40a-59ddd3b1fe2d"),
                Ulica = "Murmanska",
                Broj = 24,
                Mesto = "Beograd",
                PostanskiBroj = 114412,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("7fe60739-ee19-42cb-bb3c-4016f2214a47"),
                Ulica = "Stojana Protica",
                Broj = 12,
                Mesto = "Beograd",
                PostanskiBroj = 116468,
                Drzava = "Srbija"
            });
            modelBuilder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("febe5ad4-c954-4244-bdf5-54d351e36653"),
                Ulica = "Varvarinska",
                Broj = 32,
                Mesto = "Beograd",
                PostanskiBroj = 112810,
                Drzava = "Srbija"
            });
        }
    }
}
