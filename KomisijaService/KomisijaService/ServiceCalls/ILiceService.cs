using KomisijaService.Models;

namespace KomisijaService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za lice.
    /// </summary>
    public interface ILiceService
    {
        /// <summary>
        /// Vraća lice iz drugog mikroservisa.
        /// </summary>
        /// <param name="liceID">ID lica.</param>
        /// <param name="token">Token za lice mikroservis.</param>
        /// <returns>Vraća model DTO-a lica.</returns>
        Task<LiceDTO?> GetLiceByIDAsync(Guid liceID, string token);
    }
}
