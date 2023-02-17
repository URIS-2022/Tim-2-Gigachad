using Microsoft.EntityFrameworkCore;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Entities
{
    public class UgovorOZakupuContext : DbContext
    {
        public UgovorOZakupuContext(DbContextOptions options) : base(options) { }
        public DbSet<UgovorOZakupuEntity> Ugovori{ get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UgovorOZakupuEntity>().HasData(new
            {
                UgovorOZakupuID = Guid.Parse("dc662e18-1bb0-4f43-bb36-b20eab32a292"),
                DeoParceleID = Guid.Parse("006c5863-3eb4-4e65-afab-f3f653dec82a"),
                KupacID = Guid.Parse("035e91b3-55ab-4d36-b41b-95235a2efaa3"),
                OvlascenoLiceID = Guid.Parse("d3a26942-69f6-4f28-b5d2-05eba4b3ba1a"),
                JavnoNadmetanjeID = Guid.Parse("fa9c9d6b-e4ce-43b9-9bc9-04fc98872e19"),
                DokumentID = Guid.Parse("955b86da-6734-4972-93e5-9d46b0017bae"),
                DatumUgovora = new DateTime(2007, 01, 05),
                TrajanjeUgovora = 8,
                TipGarancije = 5
            });
            builder.Entity<UgovorOZakupuEntity>().HasData(new
            {
                UgovorOZakupuID = Guid.Parse("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"),
                DeoParceleID = Guid.Parse("ba05b8cf-42dc-4d35-b5bc-5f309b7ca43e"),
                KupacID = Guid.Parse("020c15d1-0928-4a1e-8fc1-45dcfa24c303"),
                OvlascenoLiceID = Guid.Parse("a332bcad-8049-4c73-a729-4fe6527b9ae7"),
                JavnoNadmetanjeID = Guid.Parse("c29c41d4-b729-41fe-a484-d04219fdb5a0"),
                DokumentID = Guid.Parse("f9b78e65-f70d-4d3c-81a6-f0c687925d3d"),
                DatumUgovora = new DateTime(2007, 01, 05),
                TrajanjeUgovora = 8,
                TipGarancije = 5
            });
        }
    }
}
