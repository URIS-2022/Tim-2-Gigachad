using Microsoft.EntityFrameworkCore;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Entities
{
    /// <summary>
    /// DbContext za UgovorOZakupuService mikroservis.
    /// </summary>
    public class UgovorOZakupuContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom
        /// </summary>
        /// <param name="options"></param>
        public UgovorOZakupuContext(DbContextOptions options) : base(options) { }
        /// <summary>
        /// Db set za ugovo o zakupu
        /// </summary>
        public DbSet<UgovorOZakupuEntity> Ugovori{ get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UgovorOZakupuEntity>().HasData(new
            {
                UgovorOZakupuID = Guid.Parse("dc662e18-1bb0-4f43-bb36-b20eab32a292"),
                DeoParceleID = Guid.Parse("EDF1F7CA-3B73-4CB8-8CFD-4BD615DD6ADA"),
                KupacID = Guid.Parse("CCC043C6-398C-485D-9840-092C0441EBE8"),
                JavnoNadmetanjeID = Guid.Parse("ABEC715B-03E0-4C9A-B97B-327F0AF16823"),
                DokumentID = Guid.Parse("378FFFF9-F997-4B7F-8C6E-C674918EF2E9"),
                DatumUgovora = new DateTime(2007, 03, 08),
                TrajanjeUgovora = 8,
                TipGarancije = "JEMSTVO"
            });
            modelBuilder.Entity<UgovorOZakupuEntity>().HasData(new
            {
                UgovorOZakupuID = Guid.Parse("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"),
                DeoParceleID = Guid.Parse("3846ACAF-3D0E-439A-BF27-85344934F2CA"),
                KupacID = Guid.Parse("753D20F5-73A3-4E00-A3A2-E1C43D6B0777"),
                JavnoNadmetanjeID = Guid.Parse("5D62B2C0-D13C-4F74-840F-AD96BF204D69"),
                DokumentID = Guid.Parse("C9C1CCD3-E953-490E-B69C-CF903D8758F9"),
                DatumUgovora = new DateTime(2007, 01, 05),
                TrajanjeUgovora = 8,
                TipGarancije = "BANKARSKAGARANCIJA"
            });
        }
    }
}
