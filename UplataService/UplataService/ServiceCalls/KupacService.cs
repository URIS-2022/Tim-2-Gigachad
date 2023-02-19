﻿using Newtonsoft.Json;
using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
	/// Servis poziva za kupca.
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
		/// Vraća kupca od drugog mikro servisa.
		/// </summary>
		/// <param name="KupacID">ID Kupca.</param>
		/// <param name="token">Token za kupac mikroservis.</param>
		/// <returns>Vraća model DTO-a kupca.</returns>
        public async Task<KupacDTO?> GetKupacByIDAsync(Guid KupacID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:KupacService"]}api/kupci/{KupacID}");
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
