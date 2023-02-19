using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    public interface IDokumentiService
    {
        /// <summary>
		/// Vraća adresu lica od drugog mikro servisa.
		/// </summary>
		/// <param name="dokumentID">ID adrese lica.</param>
		/// <param name="token">Token za adresu lica mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese lica.</returns>
		Task<DokumentDTO?> GetDokumentByIDAsync(Guid dokumentID, string token);
    }
}
