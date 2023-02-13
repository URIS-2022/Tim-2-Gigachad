using Microsoft.EntityFrameworkCore;

namespace LiceService.Entities
{
	public class LiceContext : DbContext
	{
		/// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public LiceContext(DbContextOptions options) : base(options) { }
		
		public DbSet<KontaktOsobaEntity> KontaktOsobe { get; set; }
		public DbSet<PravnoLiceEntity> PravnaLica { get; set; }
		public DbSet<FizickoLiceEntity> FizickaLica { get; set; }
		public DbSet<LiceEntity> Lica { get; set; }

		/// <summary>
		/// Popunjava bazu sa nekim inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
				JMBG = "4058851174218",
				Ime = "Slavomir",
				Prezime = "Slavic"
			});
			builder.Entity<FizickoLiceEntity>().HasData(new
			{
				ID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
				JMBG = "0786741214886",
				Ime = "Radomir",
				Prezime = "Radic"
			});
		}
	}
}
