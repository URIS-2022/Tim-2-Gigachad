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
                KupacID = Guid.Parse("32b7d397-b9d1-472d-bb40-541c68305098"),
                LiceID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68306098"),
                OvlascenoLiceID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305094"),
                JavnoNadmetanjeID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305018"),
                ID = Guid.Parse("32b7d397-b9d1-472d-bb40-442c68305098"),
                Prioritet = "stagodtobilo",
                ImaZabranu = false,
                DatumPocetkaZabrane = new DateTime(2003, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2008, 10, 10),
                BrojKupovina = 0
            }) ;
            builder.Entity<KupacEntity>().HasData(new
            {
                KupacID = Guid.Parse("32c7d397-b9d1-472d-bb40-542c68305098"),
                LiceID = Guid.Parse("32b4d397-b9d1-472d-bb40-542c68305098"),
                OvlascenoLiceID = Guid.Parse("12b7d397-b9d1-472d-bb40-542c68305098"),
                JavnoNadmetanjeID = Guid.Parse("32b7d367-b9d1-472d-bb40-542c68305098"),
                ID = Guid.Parse("32b7d397-b9d1-472d-bb40-549c68305098"),
                Prioritet = "stagodtobilo",
                ImaZabranu = false,
                DatumPocetkaZabrane = new DateTime(2002, 10, 10),
                DatumZavrsetkaZabrane = new DateTime(2007, 10, 10),
                BrojKupovina = 50
            });
        }
    }
}