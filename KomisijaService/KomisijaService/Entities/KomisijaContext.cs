using Microsoft.EntityFrameworkCore;

namespace KomisijaService.Entities
{
    /// <summary>
    /// DbContext za KomisijaService mikroservis.
    /// </summary>
    public class KomisijaContext : DbContext
    {
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
        /// </summary>
        public KomisijaContext(DbContextOptions options) : base(options) { }
        
        /// <summary>
        /// DbSet za entitet komisija.
        /// </summary>
        public DbSet<KomisijaEntity> Komisije { get; set; }

        /// <summary>
		/// Popunjava bazu sa nekim inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KomisijaEntity>().HasData(new
            {
                KomisijaID = Guid.Parse("4739ab8e-3f8a-413c-b65a-cec5254016e4"),
                Clan1ID = Guid.Parse("16e85d49-9cdd-41a6-85bc-180932f68999"),
                Clan2ID = Guid.Parse("334f5277-a71c-4be8-b5da-5c9148b228f7"),
                Clan3ID = Guid.Parse("92e0d8e9-b221-42a6-9bb8-a80974aee937"),
                Clan4ID = Guid.Empty,
                Clan5ID = Guid.Empty,
                PredsednikID = Guid.Parse("92e0d8e9-b221-42a6-9bb8-a80974aee937")
            });
        }
    }
}
