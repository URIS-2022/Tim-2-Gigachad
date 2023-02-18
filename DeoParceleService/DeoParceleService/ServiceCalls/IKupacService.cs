using DeoParceleService.DTO;

namespace DeoParceleService.ServiceCalls
{
	/// <summary>
	/// Interfejs od servis poziva za kupac od KupacService mikroservis.
	/// </summary>
	public interface IKupacService
	{
		/// <summary>
		/// Vraća adresu od KupacService mikroservis.
		/// </summary>
		/// <param name="kupacID">ID kupca.</param>
		/// <param name="token">Token za KupacService mikroservis.</param>
		/// <returns>Vraća model DTO kupca.</returns>
		Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string token);
	}
}
