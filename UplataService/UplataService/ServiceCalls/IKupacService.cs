using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
	/// Interfejs od servis poziva za kupca.
	/// </summary>
    public interface IKupacService
    {
        /// <summary>
		/// Vraća kupca od drugog mikro servisa.
		/// </summary>
		/// <param name="KupacID">ID Kupca.</param>
		/// <param name="token">Token za kupac mikroservis.</param>
		/// <returns>Vraća model DTO-a kupca.</returns>
		Task<KupacDTO?> GetKupacByIDAsync(Guid KupacID, string token);
    }
}
