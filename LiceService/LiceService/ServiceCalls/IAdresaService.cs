using LiceService.DTO;

namespace LiceService.ServiceCalls
{
	/// <summary>
	/// Interfejs od servis poziva za adresu od AdresaService mikroservis.
	/// </summary>
	public interface IAdresaService
	{
		/// <summary>
		/// Vraća adresu od AdresaService mikroservis.
		/// </summary>
		/// <param name="adresaID">ID adrese.</param>
		/// <param name="token">Token za AdresaService mikroservis.</param>
		/// <returns>Vraća model DTO adrese.</returns>
		Task<AdresaDTO?> GetAdresaByIDAsync(Guid adresaID, string token);
	}
}
