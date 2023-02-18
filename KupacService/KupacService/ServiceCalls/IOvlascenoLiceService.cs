using KupacService.DTO;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Interfejs servis poziva za ovlasceno lice.
    /// </summary>
    public interface IOvlascenoLiceService
    {
        /// <summary>
        /// Vraća lice drugog mikroservisa.
        /// </summary>
        /// <param name="OvlascenoLiceID">ID ovlascenog lica.</param>
        /// <param name="token">Token ovlascenog lica mikroservisa.</param>
        /// <returns>Vraća model DTO-a ovlascenog lica.</returns>
        Task<OvlascenoLiceDTO?> GetOvlascenoLiceByIDAsync(Guid OvlascenoLiceID, string token);
    }
}
