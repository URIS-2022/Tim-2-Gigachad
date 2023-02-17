using KupacService.DTO;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za adresu lica.
    /// </summary>
    public interface ILiceService
    {
        /// <summary>
        /// Vraća adresu lica od drugog mikro servisa.
        /// </summary>
        /// <param name="LiceID">ID adrese lica.</param>
        /// <param name="token">Token za adresu lica mikroservis.</param>
        /// <returns>Vraća model DTO-a adrese lica.</returns>
        Task<LiceDTO?> GetLiceByIDAsync(Guid LiceID, string token);
    }
}
