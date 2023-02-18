using OvlascenoLiceService.DTO;

namespace OvlascenoLiceService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za adresu lica.
    /// </summary>
    public interface IAdresaService
    {
        /// <summary>
        /// Vraća adresu lica od drugog mikro servisa.
        /// </summary>
        /// <param name="adresaID">ID adrese lica.</param>
        /// <param name="token">Token za adresu lica mikroservis.</param>
        /// <returns>Vraća model DTO-a adrese lica.</returns>
        Task<AdresaDTO?> GetAdresaByIDAsync(Guid adresaID, string token);
    }
}
