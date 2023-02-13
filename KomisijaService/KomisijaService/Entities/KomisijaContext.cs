using Microsoft.EntityFrameworkCore;

namespace KomisijaService.Entities
{
    public class KomisijaContext : DbContext
    {
        public DbSet<KomisijaEntity> Komisije { get; set; }

        /// <summary>
		/// Popunjava bazu sa nekim inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KomisijaEntity>().HasData(new
            {
                KomisijaID = "bc3a0d53-1862-4fbc-bb4d-7892f4199e69",
                Clan1ID = "08f2f910-eb7a-4714-9ef5-0fd1a2d1e278",
                Clan2ID = "063fe8c0-8b16-4fd5-960b-b130310040b0",
                Clan3ID = "e5875a1b-e03f-4a46-b7c2-c6f09f696034",
                Clan4ID = "b9f30780-f2e6-4475-b66e-44c588a1a252",
                Clan5ID = "63a84cc9-0c15-4acd-b2ef-c3aa44a03f7e",
                PredsednikID = "c35086d8-62c0-4166-8457-463066c8c659"
            });
            builder.Entity<KomisijaEntity>().HasData(new
            {
                KomisijaID = "9b49e647-2850-406f-9e97-6673dfeead19",
                Clan1ID = "11ab0865-2d07-4d36-8ed4-f0acb07125e2",
                Clan2ID = "beffaa0f-2933-46d3-b1bd-746e9cc4dd9e",
                Clan3ID = "b27d89c8-d41b-4357-bb59-65013d0ce874",
                Clan4ID = "fc3e799c-53e5-4f3d-b6f8-d4e53686b913",
                Clan5ID = "887414d4-c3d0-40f7-abdf-a24d41e4d6e5",
                PredsednikID = "dfbbec1a-0e37-49a1-bed0-47a5cbbb660f"
            });
        }
    }
}
