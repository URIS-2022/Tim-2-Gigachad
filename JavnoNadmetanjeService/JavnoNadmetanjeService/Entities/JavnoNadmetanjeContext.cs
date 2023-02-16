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
                //JavnoNadID = Guid.Parse("55d525cd-f780-4e0d-a27a-56721c086bd3"),
                DatumLicitacije = new DateTime(2022, 02, 02),
                Rok = new DateTime(2022, 07, 22),
                OgrnMaxPovrs = 13,
                KorakCene = 15
            });
            builder.Entity<LicitacijaEntity>().HasData(new
            {
                LicictacijaID = Guid.Parse("01724de1-1281-4206-a9ee-a153ba559304"),
                //JavnoNadID = "a6bb5697-5a8f-46e1-bc9c-4b6e1cf67efe",
                DatumLicitacije = new DateTime(2022, 10, 11),
                Rok = new DateTime(2022, 08, 19),
                OgrnMaxPovrs = 17,
                KorakCene = 150
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("73e131e6-50c4-4ce3-bcb6-b0f9c706f5cb"),
                //AdresaID = "013484ec-fa19-4f73-a288-3bfdc868c188",
                //DeoParceleID = "3c4a2c04-b462-437f-a292-18247c84813b",
                //NajbKupacID = "a363038b-6f1c-4e8d-b618-4ae682c2b4eb",
                TipNadmetanja = "tip nadmetanja 1",
                Opstina = "Sremska Mitrovica",
                DatumNad = new DateTime(2022, 08, 04),
                VremePoc = "9:37 AM",
                VremeKraj = "8:53 AM",
                PeriodZakupaM = 67,
                PocetnaCena = 1000000,
                VisinaCene = 92076,
                IzlicitiranaCena = 150000000,
                NajboljaPonuda = 13330.99,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 32,
                Krug = 7,
                StatusNadmetanja = "aktivan",
                Izuzeto = true
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("5d62b2c0-d13c-4f74-840f-ad96bf204d69"),
                //AdresaID = "32f4e80e-e489-4ac0-a0c9-a0f1ec31b5ed",
                //DeoParceleID = "d2ce90fa-a922-4cdd-9829-d48dd0981102",
                //NajbKupacID = "b3bd4a59-1300-4335-8e9c-dd2e12b67d2a",
                TipNadmetanja = "tip nadmetanja 2",
                Opstina = "Novi Sad",
                DatumNad = new DateTime(2017, 02, 19),
                VremePoc = "4:29 PM",
                VremeKraj = "10:27 AM",
                PeriodZakupaM =  28,
                PocetnaCena = 400000,
                VisinaCene = 45698,
                IzlicitiranaCena = 34000000,
                NajboljaPonuda = 97930.99,
                BrojUcesnika = 95,
                PrijavljeniKupci = 52,
                Licitanti = 39,
                Krug = 5,
                StatusNadmetanja = "zavrsen",
                Izuzeto = false
            });
            builder.Entity<JavnoNadmetanjeEntity>().HasData(new
            {
                JavnoNadID = Guid.Parse("abec715b-03e0-4c9a-b97b-327f0af16823"),
                //AdresaID = "0b38b335-28d4-43b8-8715-9369a71bd3ce",
                //DeoParceleID = "9c3cfe25-8edb-4281-a125-adb93a942f4c",
                //NajbKupacID = "24472931-dbff-4951-bbed-19f63e7ae19b",
                TipNadmetanja = "svadja na pijaci",
                Opstina = "Malo Crnice",
                DatumNad = new DateTime(2012, 05, 16),
                VremePoc = "8:32 AM",
                VremeKraj = "10:23 AM",
                PeriodZakupaM = 55,
                PocetnaCena = 45900,
                VisinaCene = 55942,
                IzlicitiranaCena = 4900000,
                NajboljaPonuda = 53.19,
                BrojUcesnika = 18,
                PrijavljeniKupci = 71,
                Licitanti = 48,
                Krug = 3,
                StatusNadmetanja = "nije zapocet",
                Izuzeto = true
            });
        }
    }
}
