using JavnoNadmetanjeService.DTO;

namespace JavnoNadmetanjeService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za kupca javnog nadmetanja.
    /// </summary>
    public interface IKupacService
    {
        /// <summary>
        /// Vraća kupca javnog nadmetanja od drugog mikro servisa.
        /// </summary>
        /// <param name="kupacID">ID kupca javnog nadmetanja.</param>
        /// <param name="token">Token za kupca javnog nadmetanja mikroservis.</param>
        /// <returns>Vraća model DTO-a kupca javnog nadmetanja.</returns>
        Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string token);
    }
}
