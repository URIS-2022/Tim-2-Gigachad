using KupacService.DTO;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Interfejs servis poziva za lica.
    /// </summary>
    public interface ILiceService
    {
        /// <summary>
        /// Vraća adresu lica drugog mikroservisa.
        /// </summary>
        /// <param name="LiceID">ID lica.</param>
        /// <param name="token">Token za lice mikroservis.</param>
        /// <returns>Vraća model DTO-a lica.</returns>
        Task<LiceDTO?> GetLiceByIDAsync(Guid LiceID, string token);
    }
}
