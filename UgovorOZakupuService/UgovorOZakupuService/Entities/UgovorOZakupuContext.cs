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
                DeoParceleID = Guid.Parse("EDF1F7CA-3B73-4CB8-8CFD-4BD615DD6ADA"),
                KupacID = Guid.Parse("CCC043C6-398C-485D-9840-092C0441EBE8"),
                JavnoNadmetanjeID = Guid.Parse("fa9c9d6b-e4ce-43b9-9bc9-04fc98872e19"),
                DokumentID = Guid.Parse("CBAF109E-4CBA-4382-9A65-8EACF0567B4D"),
                DatumUgovora = new DateTime(2007, 03, 08),
                TrajanjeUgovora = 8,
                TipGarancije = "JEMSTVO"
            });
            builder.Entity<UgovorOZakupuEntity>().HasData(new
            {
                UgovorOZakupuID = Guid.Parse("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"),
                DeoParceleID = Guid.Parse("3846ACAF-3D0E-439A-BF27-85344934F2CA"),
                KupacID = Guid.Parse("753D20F5-73A3-4E00-A3A2-E1C43D6B0777"),
                JavnoNadmetanjeID = Guid.Parse("c29c41d4-b729-41fe-a484-d04219fdb5a0"),
                DokumentID = Guid.Parse("8F807775-67A4-4C52-825C-63CC8DA27C98"),
                DatumUgovora = new DateTime(2007, 01, 05),
                TrajanjeUgovora = 8,
                TipGarancije = "BANKARSKAGARANCIJA"
            });
        }
    }
}
