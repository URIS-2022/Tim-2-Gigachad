using Newtonsoft.Json;
using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    /// <summary>
    /// Interfejs od dela parcele service
    /// </summary>
    public class DeoParceleService : IDeoParceleService
    {
            private readonly IConfiguration configuration;
            /// <summary>
            /// Dependency injection za konfiguraciju
            /// </summary>
            /// <param name="configuration"></param>
            public DeoParceleService(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            /// <summary>
            /// Vraća adresu dela parcele od drugog mikro servisa.
            /// </summary>
            /// <param name="deoParceleID">ID adrese dokumenta.</param>
            /// <param name="token">Token za adresu dokumenta mikroservis.</param>
            /// <returns>Vraća model DTO-a adrese dokumenta.</returns>
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
