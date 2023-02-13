using Microsoft.EntityFrameworkCore;

namespace UplataService.Entities
{
    public class UplataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public UplataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<UplataEntity> Uplate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UplataDB"));
        }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UplataEntity>().HasData(new
            {
                UplataID = Guid.Parse("460f3547-d626-49d7-92c4-6f96ae3714e0"),
                JavnoNadmetanjeID = Guid.Parse("03b0680e-35b6-4449-9150-019b817d7cef"),
                KupacID = Guid.Parse("96e691db-3fee-44af-a0db-e51660b53bb4"),
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
                JavnoNadmetanjeID = Guid.Parse("43d6bc15-a674-4552-abee-f3c3360db11e"),
                KupacID = Guid.Parse("47dc24c8-b4d4-49f2-a995-ba38d944a2b2"),
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
