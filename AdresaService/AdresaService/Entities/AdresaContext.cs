using Microsoft.EntityFrameworkCore;

namespace AdresaService.Entities
{
    public class AdresaContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AdresaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<AdresaEntity> Adresa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AdresaDB"));
        }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Ulica = "Slavoja Perica",
                Broj = 11,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                Ulica = "Dositejeva",
                Broj = 23,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
        }
    }
}
