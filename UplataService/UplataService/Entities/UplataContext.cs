using Microsoft.EntityFrameworkCore;

namespace UplataService.Entities
{
    /// <summary>
	/// DbContext za UplataService mikroservis.
	/// </summary>
    public class UplataContext : DbContext
    {
        private readonly IConfiguration configuration;

        /// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
        public UplataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        /// <summary>
		/// DbSet za entitet uplata.
		/// </summary>
        public DbSet<UplataEntity> Uplate { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UplataEntity>().HasData(new
            {
                UplataID = Guid.Parse("460f3547-d626-49d7-92c4-6f96ae3714e0"),
                JavnoNadmetanjeID = Guid.Parse("ABEC715B-03E0-4C9A-B97B-327F0AF16823"),
                KupacID = Guid.Parse("CCC043C6-398C-485D-9840-092C0441EBE8"),
                BrojRacuna = "005-417672-67",
                PozivNaBroj = "73609",
                Iznos = 45000,
                Uplatilac = "Pera Peric",
                SvrhaUplate = "Uplata na racun",
                DatumUplate = new DateTime(2022, 3, 4),
                //Katastrofa je DateTime za rad
                KursnaLista = "???????"
            });
            builder.Entity<UplataEntity>().HasData(new
            {
                UplataID = Guid.Parse("167ef647-33c2-466c-b777-5271365bffbd"),
                JavnoNadmetanjeID = Guid.Parse("5D62B2C0-D13C-4F74-840F-AD96BF204D69"),
                KupacID = Guid.Parse("753D20F5-73A3-4E00-A3A2-E1C43D6B0777"),
                BrojRacuna = "214-826330-03",
                PozivNaBroj = "18096",
                Iznos = 1550,
                Uplatilac = "Sima Simic",
                SvrhaUplate = "Racun za Telenor",
                DatumUplate = new DateTime(2022, 5, 10),
                //Katastrofa je DateTime za rad
                KursnaLista = "???????"
            });
        }
    }
}
