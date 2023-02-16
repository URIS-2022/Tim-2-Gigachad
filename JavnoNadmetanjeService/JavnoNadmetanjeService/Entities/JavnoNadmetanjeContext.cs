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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LicitacijaEntity>().HasData(new
            {
                LicictacijaID = Guid.Parse("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                DatumLicitacije = new DateTime(2022, 02, 02),
                Rok = new DateTime(2022, 07, 22),
                OgrnMaxPovrs = 13,
                KorakCene = 15
            });
            builder.Entity<LicitacijaEntity>().HasData(new
            {
                LicictacijaID = Guid.Parse("01724de1-1281-4206-a9ee-a153ba559304"),
                DatumLicitacije = new DateTime(2022, 10, 11),
                Rok = new DateTime(2022, 08, 19),
                OgrnMaxPovrs = 17,
                KorakCene = 150
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                LicictacijaID = Guid.Parse("1ecaca89-af8e-47d5-8a33-5f4ec2fcb04e"),
                AdresaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                DeoParceleID = Guid.Parse("3c4a2c04-b462-437f-a292-18247c84813b"),
                NajbKupacID = Guid.Parse("a363038b-6f1c-4e8d-b618-4ae682c2b4eb"),
                TipNadmetanja = "JAVNA_LICITACIJA",
                Opstina = "BIKOVO",
                DatumNad = new DateTime(2022, 08, 04),
                VremePoc = new TimeSpan(8, 53, 0),
                VremeKraj = new TimeSpan(9, 37, 0),
                PeriodZakupaM = 67,
                PocetnaCena = 1000000,
                VisinaCene = 92076,
                IzlicitiranaCena = 150000000,
                NajboljaPonuda = 13330.99,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 32,
                Krug = 7,
                StatusNadmetanja = "PRVI_KRUG",
                Izuzeto = true
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                LicictacijaID = Guid.Parse("01724de1-1281-4206-a9ee-a153ba559304"),
                AdresaID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                DeoParceleID = Guid.Parse("d2ce90fa-a922-4cdd-9829-d48dd0981102"),
                NajbKupacID = Guid.Parse("b3bd4a59-1300-4335-8e9c-dd2e12b67d2a"),
                TipNadmetanja = "OTVARANJE_ZATVORENIH_PONUDA",
                Opstina = "ZEDNIK",
                DatumNad = new DateTime(2017, 02, 19),
                VremePoc = new TimeSpan(16, 29, 0),
                VremeKraj = new TimeSpan(18, 27, 0),
                PeriodZakupaM =  28,
                PocetnaCena = 400000,
                VisinaCene = 45698,
                IzlicitiranaCena = 34000000,
                NajboljaPonuda = 97930.99,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 39,
                Krug = 5,
                StatusNadmetanja = "DRUGI_KRUG_STARI",
                Izuzeto = false
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("abec715b-03e0-4c9a-b97b-327f0af16823"),
                AdresaID = Guid.Parse("878100df-6973-4292-acb1-0c25b7ac2260"),
                DeoParceleID = Guid.Parse("9c3cfe25-8edb-4281-a125-adb93a942f4c"),
                NajbKupacID = Guid.Parse("24472931-dbff-4951-bbed-19f63e7ae19b"),
                TipNadmetanja = "JAVNA_LICITACIJA",
                Opstina = "DONJI_GRAD",
                DatumNad = new DateTime(2012, 05, 16),
                VremePoc = new TimeSpan(8, 32, 0),
                VremeKraj = new TimeSpan(10, 23, 0),
                PeriodZakupaM = 55,
                PocetnaCena = 45900,
                VisinaCene = 55942,
                IzlicitiranaCena = 4900000,
                NajboljaPonuda = 53.19,
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
