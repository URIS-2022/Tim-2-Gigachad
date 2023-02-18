using KupacService.DTO;
using Newtonsoft.Json;

namespace KupacService.ServiceCalls
{
    /// <summary>
    /// Servis poziva za ovlasceno lice.
    /// </summary>
    public class OvlascenoLiceService : IOvlascenoLiceService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Dependency injection za konfiguraciju konekcije.
        /// </summary>
        public OvlascenoLiceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Vraća ovlasceno lice od drugog mikroservisa.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenog lica.</param>
        /// <param name="token">Token za ovlasceno lice mikroservis.</param>
        /// <returns>Vraća model DTO-a ovlsacenog lica.</returns>
        public async Task<OvlascenoLiceDTO?> GetOvlascenoLiceByIDAsync(Guid ovlascenoLiceID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:OvlascenoLiceService"]}api/ovlascenaLica/{ovlascenoLiceID}");
            if (token != string.Empty)
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            OvlascenoLiceDTO? ovlascenoLice;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                ovlascenoLice = JsonConvert.DeserializeObject<OvlascenoLiceDTO?>(responseContent);
            }
            else
                ovlascenoLice = null;

            if (ovlascenoLice != null && ovlascenoLice.ID != Guid.Empty)
                return ovlascenoLice;
            else
                return null;
        }
    }
}

