using Microsoft.EntityFrameworkCore;

namespace KorisniciService.Entities
{
    public class KorisnikContext : DbContext
    {
        private readonly IConfiguration configuration;

        public KorisnikContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<KorisnikEntity> Korisnici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("KorisniciDB"));
        }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KorisnikEntity>().HasData(new
            {
                KorisnikID = Guid.Parse("6e1a8ee2-c01d-484c-9da8-e50427fb298e"),
                JavnoNadmetanjeID = Guid.Parse("b49180d8-ff63-462d-8868-02c26ec0304c"),
                TipKorisnika = "Tehnicki sekretar",
                Naziv = "Wynn Lagadu",
                Sifra = "EjfkRqXrltLI"
            });
            builder.Entity<KorisnikEntity>().HasData(new
            {
                KorisnikID = Guid.Parse("b0d223dd-c5f4-4bc3-ab9c-f83d8e374b1e"),
                JavnoNadmetanjeID = Guid.Parse("ce3c6508-b4d6-4b03-83c2-646baf4ed78b"),
                TipKorisnika = "Operater Nadmetanja",
                Naziv = "Manuel Andriessen",
                Sifra = "n4xxvQyQm"
            });
        }
    }
}
