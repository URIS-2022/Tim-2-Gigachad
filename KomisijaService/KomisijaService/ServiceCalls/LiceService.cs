using KomisijaService.Models;
using Newtonsoft.Json;

namespace KomisijaService.ServiceCalls
{
    /// <summary>
    /// Servis poziva za lice.
    /// </summary>
    public class LiceService : ILiceService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Dependency injection za konfiguraciju konekcije.
        /// </summary>
        public LiceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
		/// Vraća adresu lica od drugog mikro servisa.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <param name="token">Token za lice mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese lica.</returns>
		public async Task<LiceDTO?> GetLiceByIDAsync(Guid liceID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:LiceService"]}api/lica/{liceID}");
            if (token != string.Empty)
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            LiceDTO? lice;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                lice = JsonConvert.DeserializeObject<LiceDTO?>(responseContent);
            }
            else
                lice = null;

            if (lice != null && lice.ID != Guid.Empty)
                return lice;
            else
                return null;
        }
    }
}
