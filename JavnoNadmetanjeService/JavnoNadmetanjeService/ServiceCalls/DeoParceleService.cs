using JavnoNadmetanjeService.DTO;
using Newtonsoft.Json;

namespace JavnoNadmetanjeService.ServiceCalls
{
    /// <summary>
	/// Servis poziva za deo parcele.
	/// </summary>
    public class DeoParceleService : IDeoParceleService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Dependency injection za konfiguraciju konekcije.
        /// </summary>
        public DeoParceleService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Vraća deo parcele od drugog mikro servisa.
        /// </summary>
        /// <param name="deoParceleID">ID dela parcele.</param>
        /// <param name="token">Token za deo parcele mikroservis.</param>
        /// <returns>Vraća model DTO-a dela parcele.</returns>
        public async Task<DeoParceleDTO?> GetDeoParceleByIDAsync(Guid deoParceleID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:DeoParceleService"]}api/deloviParcela/{deoParceleID}");
            if (token != string.Empty)
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            DeoParceleDTO? deoParcele;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                deoParcele = JsonConvert.DeserializeObject<DeoParceleDTO?>(responseContent);
            }
            else
                deoParcele = null;
            if (deoParcele != null && deoParcele.ID != Guid.Empty)
                return deoParcele;
            else
                return null;
        }
    }
}
