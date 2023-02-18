﻿using JavnoNadmetanjeService.DTO;
using Newtonsoft.Json;

namespace JavnoNadmetanjeService.ServiceCalls
{
    /// <summary>
	/// Servis poziva za najboljeg kupca javnog nadmetanja.
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
        /// Vraća kupca javnog nadmetanja od drugog mikro servisa.
        /// </summary>
        /// <param name="najboljiKupacID">ID kupca javnog nadmetanja.</param>
        /// <param name="token">Token za kupca javnog nadmetanja mikroservis.</param>
        /// <returns>Vraća model DTO-a kupca javnog nadmetanja.</returns>
        public async Task<KupacDTO?> GetKupacByIDAsync(Guid najboljiKupacID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:KupacService"]}api/kupci/{najboljiKupacID}");
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
