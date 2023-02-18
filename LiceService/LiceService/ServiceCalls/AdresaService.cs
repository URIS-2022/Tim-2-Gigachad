using LiceService.DTO;
using Newtonsoft.Json;

namespace LiceService.ServiceCalls
{
	/// <summary>
	/// Servis poziva za adresu od AdresaService mikroservis.
	/// </summary>
	public class AdresaService : IAdresaService
	{
		private readonly IConfiguration configuration;

		/// <summary>
		/// Dependency injection za konfiguraciju konekcije.
		/// </summary>
		public AdresaService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		/// <summary>
		/// Vraća adresu od AdresaService mikroservis.
		/// </summary>
		/// <param name="adresaID">ID adrese.</param>
		/// <param name="token">Token za AdresaService mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese.</returns>
		public async Task<AdresaDTO?> GetAdresaByIDAsync(Guid adresaID, string? token)
		{
			using HttpClient httpClient = new();
			Uri url = new($"{configuration["Services:AdresaService"]}api/adrese/{adresaID}");
			if (token != string.Empty)
				httpClient.DefaultRequestHeaders.Add("Authorization", token);

			HttpResponseMessage response = httpClient.GetAsync(url).Result;
			AdresaDTO? adresa;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = await response.Content.ReadAsStringAsync();
				adresa = JsonConvert.DeserializeObject<AdresaDTO?>(responseContent);
			}
			else
				adresa = null;
			if (adresa != null && adresa.ID != Guid.Empty)
				return adresa;
			else
				return null;
		}
	}
}
