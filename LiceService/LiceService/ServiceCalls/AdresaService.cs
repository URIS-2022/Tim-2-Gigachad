﻿using LiceService.DTO;
using Newtonsoft.Json;

namespace LiceService.ServiceCalls
{
	/// <summary>
	/// Servis poziva za adresu lica.
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
		/// Vraća adresu lica od drugog mikro servisa.
		/// </summary>
		/// <param name="adresaLicaID">ID adrese lica.</param>
		/// <param name="token">Token za adresu lica mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese lica.</returns>
		public async Task<AdresaLicaDTO?> GetAdresaByIDAsync(Guid adresaLicaID, string? token)
		{
			using HttpClient httpClient = new();
			Uri url = new ($"{configuration["Services:AdresaService"]}api/adrese/{adresaLicaID}");
			if (token != string.Empty)
				httpClient.DefaultRequestHeaders.Add("Authorization", token);

			HttpResponseMessage response = httpClient.GetAsync(url).Result;

			string responseContent = await response.Content.ReadAsStringAsync();
			AdresaLicaDTO? adresa = JsonConvert.DeserializeObject<AdresaLicaDTO?>(responseContent);

			return adresa;
		}
	}
}