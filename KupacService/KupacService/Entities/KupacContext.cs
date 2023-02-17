using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace KupacService.Entities
{
    public class KupacContext : DbContext
    {
        //private readonly IConfiguration configuration;

        public KupacContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {

        }

        public DbSet<KupacEntity> Kupci { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("KupacDB"));
        //}

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("34b7d397-b9d1-472d-bb40-541c69305098"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305094"),
                JavnoNadmetanjeID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305018"),
                Prioritet = "VLASNIKSISTEMAZANAVODNJAVANJE",
                ImaZabranu = true,
                DatumPocetkaZabrane = new DateTime(2000, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2008, 10, 10),
                BrojKupovina = 0
            }) ;
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("34b7d397-b9d1-472d-bb40-541c69305097"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("12b7d397-b9d1-472d-bb40-542c68305098"),
                JavnoNadmetanjeID = Guid.Parse("32b7d367-b9d1-472d-bb40-542c68305098"),
                Prioritet = "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR",
                ImaZabranu = false,
                BrojKupovina = 50
            });
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("34b7d397-b9d1-472d-bb40-541c69305096"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("12b7d397-b9d1-472d-bb40-542c68305098"),
                JavnoNadmetanjeID = Guid.Parse("32b7d367-b9d1-472d-bb40-542c68305098"),
                Prioritet = "VLASNIKSISTEMAZANAVODNJAVANJE",
                ImaZabranu = false,
                BrojKupovina = 20
            });
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("32c7d797-b9d1-472d-bb40-542c68605098"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("12b7d397-b9d1-472d-bb40-542c68305098"),
                JavnoNadmetanjeID = Guid.Parse("32b7d367-b9d1-472d-bb40-542c68305098"),
                Prioritet = "POLJOPRIVREDNIKKOJIJEUPISANUREGISTAR",
                ImaZabranu = true,
                DatumPocetkaZabrane = new DateTime(2005, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2007, 10, 10),
                BrojKupovina = 10
            });
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("32c7d297-b9d1-472d-bb40-542c68305698"),
                LiceID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                OvlascenoLiceID = Guid.Parse("12b7d397-b9d1-472d-bb40-542c68305098"),
                JavnoNadmetanjeID = Guid.Parse("32b7d367-b9d1-472d-bb40-542c68305098"),
                Prioritet = "VLASNIKZEMLJISTAKOJEJENAJBLIZEZEMLJISTUKOJESEDAJEUZAKUP",
                ImaZabranu = false,
                BrojKupovina = 30
            });

        }
    }
}