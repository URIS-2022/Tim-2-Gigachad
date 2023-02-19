using Microsoft.EntityFrameworkCore;

namespace OvlascenoLiceService.Entities
{
    /// <summary>
    /// DbContext za OvlascenoLiceService mikroservis.
    /// </summary>
    public class OvlascenoLiceContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public OvlascenoLiceContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet za entitet fizičko lice.
        /// </summary>
        public DbSet<FizickoLiceEntity> FizickaLica { get; set; }

        /// <summary>
        /// DbSet za entitet ovlasceno lice.
        /// </summary>
        public DbSet<OvlascenoLiceEntity> OvlascenaLica { get; set; }

        /// <summary>
        /// Popunjava bazu inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FizickoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("8cc7d67a-61ed-4795-ad0a-fa882eda0a2b"),
                JMBG = "4058851174218",
                Ime = "Slavomirko",
                Prezime = "Slavimirkovic"
            });
            modelBuilder.Entity<FizickoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("af948f2a-745b-45bc-abc1-1f4da1727af4"),
                JMBG = "0786741214886",
                Ime = "Radomirko",
                Prezime = "Radimirkovic"
            });
            modelBuilder.Entity<FizickoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("194e73cb-831e-40da-9ec8-0751c04a6b28"),
                JMBG = "0925639560129",
                Ime = "Miladinko",
                Prezime = "Miladinkovic"
            });
            modelBuilder.Entity<FizickoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("673eb87d-4a9f-4838-a542-3d4cef1b9495"),
                JMBG = "9195579483423",
                Ime = "Milasinko",
                Prezime = "Milasnkovic"
            });
            modelBuilder.Entity<FizickoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("4c504a89-419a-4f6f-8aae-31e0d3823e39"),
                JMBG = "6675836696997",
                Ime = "Radasinko",
                Prezime = "Radasinkovic"
            });

            modelBuilder.Entity<OvlascenoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("7b50cce0-050d-4833-bbc7-6b910bb6da89"),
                FizickoLiceID = Guid.Parse("af948f2a-745b-45bc-abc1-1f4da1727af4"),
                PravnoLiceID = Guid.Empty,
                AdresaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Telefon1 = "4211218533",
                Telefon2 = "399461094",
                Email = "email1@net.org",
                BrojRacuna = "343658891760636"
            });
            modelBuilder.Entity<OvlascenoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("1e24bea9-7df2-4d14-b224-c76fd77536dd"),
                FizickoLiceID = Guid.Parse("af948f2a-745b-45bc-abc1-1f4da1727af4"),
                AdresaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Telefon1 = "377172253",
                Telefon2 = "8048668952",
                Email = "email2@net.org",
                BrojRacuna = "788066876873835"
            });
            modelBuilder.Entity<OvlascenoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("145c1e74-7eb5-4eaa-bf6a-bb84921c871e"),
                FizickoLiceID = Guid.Parse("673eb87d-4a9f-4838-a542-3d4cef1b9495"),
                AdresaID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Telefon1 = "4461663339",
                Telefon2 = "4815540720",
                Email = "email3@net.org",
                BrojRacuna = "801272932440773"
            });
            modelBuilder.Entity<OvlascenoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("904bd8b6-e268-4ca8-89fb-ef2750a74e19"),
                FizickoLiceID = Guid.Parse("673eb87d-4a9f-4838-a542-3d4cef1b9495"),
                AdresaID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                Telefon1 = "2481909941",
                Telefon2 = string.Empty,
                Email = "email4@net.org",
                BrojRacuna = "854823918379735"
            });
            modelBuilder.Entity<OvlascenoLiceEntity>().HasData(new
            {
                ID = Guid.Parse("faea6877-c81e-4829-987e-ea68d5aea752"),
                FizickoLiceID = Guid.Parse("4c504a89-419a-4f6f-8aae-31e0d3823e39"),
                AdresaID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                Telefon1 = "5528150968",
                Telefon2 = string.Empty,
                Email = "email5@net.org",
                BrojRacuna = "252614852215342"
            });
        }
    }
}