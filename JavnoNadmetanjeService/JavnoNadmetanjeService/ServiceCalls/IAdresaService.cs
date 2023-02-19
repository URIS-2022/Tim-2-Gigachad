using JavnoNadmetanjeService.DTO;

namespace JavnoNadmetanjeService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za adresu javnog nadmetanja.
    /// </summary>
    public interface IAdresaService
    {
        /// <summary>
        /// Vraća adresu javnog nadmetanja od drugog mikro servisa.
        /// </summary>
        /// <param name="adresaID">ID adrese javnog nadmetanja.</param>
        /// <param name="token">Token za adresu javnog nadmetanja mikroservis.</param>
        /// <returns>Vraća model DTO-a adrese javnog nadmetanja.</returns>
        Task<AdresaDTO?> GetAdresaByIDAsync(Guid adresaID, string token);
    }
}
