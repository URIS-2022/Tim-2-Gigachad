using Microsoft.EntityFrameworkCore;

namespace DeoParceleService.Entities
{
	/// <summary>
	/// DbContext za DeoParceleService mikroservis.
	/// </summary>
	public class DeoParceleContext : DbContext
	{
		/// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public DeoParceleContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// DbSet za entitet parcela.
		/// </summary>
		public DbSet<ParcelaEntity> Parcele { get; set; }

		/// <summary>
		/// DbSet za entitet deo parcela.
		/// </summary>
		public DbSet<DeoParceleEntity> DeloviParcela { get; set; }

		/// <summary>
		/// Popunjava bazu sa inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder builder)
		{

		}
	}
}
