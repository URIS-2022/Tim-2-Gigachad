using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za deo parcele od KupacService servis
    /// </summary>
    public interface IKupacService
    {
        /// <summary>
		/// Vraća adresu lica od drugog mikro servisa.
		/// </summary>
		/// <param name="kupacID">ID adrese lica.</param>
		/// <param name="token">Token za adresu lica mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese lica.</returns>
		Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string token);
    }
}
