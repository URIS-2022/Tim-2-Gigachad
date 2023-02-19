using ZalbaService.Models;

namespace ZalbaService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za kupca.
    /// </summary>
    public interface IKupacService
    {
        /// <summary>
        /// Vraća kupca iz drugog mikroservisa.
        /// </summary>
        /// <param name="kupacID">ID kupca.</param>
        /// <param name="token">Token za kupac mikroservis.</param>
        /// <returns>Vraća model DTO-a kupca.</returns>
        Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string token);
    }
}
