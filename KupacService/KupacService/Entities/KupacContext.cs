using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace KupacService.Entities
{
    /// <summary>
    /// DbContext za KupacService mikroservis.
    /// </summary>
    public class KupacContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public KupacContext(DbContextOptions options, IConfiguration configuration) : base(options) {}

        /// <summary>
        /// DbSet za entitet kupac.
        /// </summary>
        public DbSet<KupacEntity> Kupci { get; set; }

        /// <summary>
        /// Popunjava bazu nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("ccc043c6-398c-485d-9840-092c0441ebe8"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("1e24bea9-7df2-4d14-b224-c76fd77536dd"),
                Prioritet = "VLASNIKSISTEMAZANAVODNJAVANJE",
                ImaZabranu = true,
                DatumPocetkaZabrane = new DateTime(2000, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2008, 10, 10),
                BrojKupovina = 0
            }) ;
            modelBuilder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("93d92981-a754-41d8-8d1f-b5462a9e0386"),
                LiceID = Guid.Parse("92e0d8e9-b221-42a6-9bb8-a80974aee937"),
                OvlascenoLiceID = Guid.Parse("1e24bea9-7df2-4d14-b224-c76fd77536dd"),
                Prioritet = "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR",
                ImaZabranu = false,
                DatumPocetkaZabrane = (DateTime?)null,
                DatumZavrsetkaZabrane = (DateTime?)null,
                BrojKupovina = 50
            });
            modelBuilder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
                LiceID = Guid.Parse("f127642e-4d73-42f1-979d-6a506aea9bdc"),
                OvlascenoLiceID = Guid.Parse("904bd8b6-e268-4ca8-89fb-ef2750a74e19"),
                Prioritet = "VLASNIKSISTEMAZANAVODNJAVANJE",
                ImaZabranu = false,
                DatumPocetkaZabrane = (DateTime?)null,
                DatumZavrsetkaZabrane = (DateTime?)null,
                BrojKupovina = 20
            });
            modelBuilder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
                LiceID = Guid.Parse("16e85d49-9cdd-41a6-85bc-180932f68999"),
                OvlascenoLiceID = Guid.Parse("904bd8b6-e268-4ca8-89fb-ef2750a74e19"),
                Prioritet = "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR",
                ImaZabranu = true,
                DatumPocetkaZabrane = new DateTime(2005, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2007, 10, 10),
                BrojKupovina = 10
            });
            modelBuilder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"),
                LiceID = Guid.Parse("41d2c8bc-0c8c-4fb2-8cf6-2918c33eac9c"),
                OvlascenoLiceID = Guid.Parse("faea6877-c81e-4829-987e-ea68d5aea752"),
                Prioritet = "VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP",
                ImaZabranu = false,
                DatumPocetkaZabrane = (DateTime?) null,
                DatumZavrsetkaZabrane = (DateTime?)null,
                BrojKupovina = 30
            });

        }
    }
}