using JavnoNadmetanjeService.DTO;

namespace JavnoNadmetanjeService.ServiceCalls
{
    /// <summary>
    /// Interfejs od servis poziva za deo parcele.
    /// </summary>
    public interface IDeoParceleService
    {
        /// <summary>
        /// Vraća deo parcele od drugog mikro servisa.
        /// </summary>
        /// <param name="deoParceleID">ID dela parcele.</param>
        /// <param name="token">Token za deo parcele mikroservis.</param>
        /// <returns>Vraća model DTO-a dela parcele.</returns>
        Task<DeoParceleDTO?> GetDeoParceleByIDAsync(Guid deoParceleID, string token);
    }
}
