using Newtonsoft.Json;
using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    /// <summary>
    /// Interfejs za KupacService
    /// </summary>
    public class KupacService : IKupacService
    {
        private readonly IConfiguration configuration;
        /// <summary>
        /// Dependency injection za konfiguraciju   
        /// </summary>
        /// <param name="configuration"></param>
        public KupacService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
		/// Vraća adresu dokumenta od drugog mikro servisa.
		/// </summary>
		/// <param name="kupacID">ID adrese dokumenta.</param>
		/// <param name="token">Token za adresu dokumenta mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese dokumenta.</returns>
        public async Task<KupacDTO?> GetKupacByIDAsync(Guid kupacID, string token)
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
