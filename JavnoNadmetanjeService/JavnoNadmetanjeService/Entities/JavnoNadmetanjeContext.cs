using Microsoft.EntityFrameworkCore;

namespace JavnoNadmetanjeService.Entities
{
    /// <summary>
	/// DbContext za JavnoNadmetanjeService mikroservis.
	/// </summary>
    public class JavnoNadmetanjeContext : DbContext
    {
        /// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
        public JavnoNadmetanjeContext(DbContextOptions options) : base(options) { }

        /// <summary>
		/// DbSet za entitet javno nadmetanje.
		/// </summary>
        public DbSet<JavnoNadmetanjeEntity> JavnoNadmetanje { get; set; }

        /// <summary>
		/// DbSet za entitet licitacija.
		/// </summary>
        public DbSet<LicitacijaEntity> Licitacija { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicitacijaEntity>().HasData(new
            {
                ID = Guid.Parse("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                DatumLicitacije = new DateTime(2022, 02, 02),
                Rok = new DateTime(2022, 07, 22),
                OgrnMaxPovrs = 13,
                KorakCene = 15
            });
            modelBuilder.Entity<LicitacijaEntity>().HasData(new
            {
                ID = Guid.Parse("01724de1-1281-4206-a9ee-a153ba559304"),
                DatumLicitacije = new DateTime(2022, 10, 11),
                Rok = new DateTime(2022, 11, 19),
                OgrnMaxPovrs = 17,
                KorakCene = 150
            });
            modelBuilder.Entity<LicitacijaEntity>().HasData(new
            {
                ID = Guid.Parse("77eb8e4b-ede1-4825-8da2-72d14c2d7259"),
                DatumLicitacije = new DateTime(2023, 01, 11),
                Rok = new DateTime(2023, 02, 18),
                OgrnMaxPovrs = 17,
                KorakCene = 150
            });
            modelBuilder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                ID = Guid.Parse("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                LicitacijaID = Guid.Parse("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                AdresaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                DeoParceleID = Guid.Parse("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"),
                KupacID = Guid.Parse("ccc043c6-398c-485d-9840-092c0441ebe8"),
                TipNadmetanja = "JAVNA_LICITACIJA",
                Opstina = "BIKOVO",
                DatumNad = new DateTime(2022, 08, 04),
                VremePoc = new DateTime(2022, 08, 04, 08, 45, 00),
                VremeKraj = new DateTime(2022, 08, 04, 10, 30, 00),
                PeriodZakupa = 67,
                PocetnaCena = 1000000,
                VisinaCene = 92076,
                IzlicitiranaCena = 150000000,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 32,
                Krug = 7,
                StatusNadmetanja = "PRVI_KRUG",
                Izuzeto = true
            });
            modelBuilder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                ID = Guid.Parse("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                LicitacijaID = Guid.Parse("01724de1-1281-4206-a9ee-a153ba559304"),
                AdresaID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                DeoParceleID = Guid.Parse("3846acaf-3d0e-439a-bf27-85344934f2ca"),
                KupacID = Guid.Parse("93d92981-a754-41d8-8d1f-b5462a9e0386"),
                TipNadmetanja = "OTVARANJE_ZATVORENIH_PONUDA",
                Opstina = "ZEDNIK",
                DatumNad = new DateTime(2019, 05, 25),
                VremePoc = new DateTime(2019, 05, 25, 10, 00, 00),
                VremeKraj = new DateTime(2019, 05, 25, 12, 30, 00),
                PeriodZakupa =  28,
                PocetnaCena = 400000,
                VisinaCene = 45698,
                IzlicitiranaCena = 34000000,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 39,
                Krug = 5,
                StatusNadmetanja = "DRUGI_KRUG_STARI",
                Izuzeto = false
            });
            modelBuilder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                ID = Guid.Parse("abec715b-03e0-4c9a-b97b-327f0af16823"),
                LicitacijaID = Guid.Parse("77eb8e4b-ede1-4825-8da2-72d14c2d7259"),
                AdresaID = Guid.Parse("878100df-6973-4292-acb1-0c25b7ac2260"),
                DeoParceleID = Guid.Parse("dacea418-fdcc-4289-8a94-df82a7056c18"),
                KupacID = Guid.Parse("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
                TipNadmetanja = "JAVNA_LICITACIJA",
                Opstina = "DONJI_GRAD",
                DatumNad = new DateTime(2023, 01, 16),
                VremePoc = new DateTime(2023, 01, 16, 07, 30, 00),
                VremeKraj = new DateTime(2023, 01, 16, 09, 00, 00),
                PeriodZakupa = 55,
                PocetnaCena = 45900,
                VisinaCene = 55942,
                IzlicitiranaCena = 4900000,
                BrojUcesnika = 18,
                PrijavljeniKupci = 71,
                Licitanti = 48,
                Krug = 3,
                StatusNadmetanja = "DRUGI_KRUG_NOVI",
                Izuzeto = true
            });
        }
    }
}
