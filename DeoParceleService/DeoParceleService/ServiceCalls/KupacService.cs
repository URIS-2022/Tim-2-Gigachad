using DeoParceleService.DTO;
using Newtonsoft.Json;

namespace DeoParceleService.ServiceCalls
{
	/// <summary>
	/// Interfejs od servis poziva za kupac od KupacService mikroservis.
	/// </summary>
	public class KupacService : IKupacService
	{
		private readonly IConfiguration configuration;

		/// <summary>
		/// Dependency injection za konfiguraciju konekcije.
		/// </summary>
		public KupacService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		/// <summary>
		/// Vraća adresu od KupacService mikroservis.
		/// </summary>
		/// <param name="kupacID">ID kupca.</param>
		/// <param name="token">Token za KupacService mikroservis.</param>
		/// <returns>Vraća model DTO kupca.</returns>
		public async Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string? token)
		{
			using HttpClient httpClient = new();
			Uri url = new($"{configuration["Services:KupacService"]}api/kupci/{kupacID}");
			if (token != string.Empty)
				httpClient.DefaultRequestHeaders.Add("Authorization", token);

			HttpResponseMessage response = httpClient.GetAsync(url).Result;
			KupacDTO? kupac;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = await response.Content.ReadAsStringAsync();
				kupac = JsonConvert.DeserializeObject<KupacDTO?>(responseContent);
			}
			else
				kupac = null;

			if (kupac != null && kupac.KupacID != Guid.Empty)
				return kupac;
			else
				return null;
		}
	}
}
