using Newtonsoft.Json;
using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
	/// Servis poziva za javno nadmetanje.
	/// </summary>
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Dependency injection za konfiguraciju konekcije.
        /// </summary>
        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
		/// Vraća javno nadmetanje od drugog mikro servisa.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <param name="token">Token za javno nadmetanje mikroservis.</param>
		/// <returns>Vraća model DTO-a javno nadmetanje.</returns>
        public async Task<JavnoNadmetanjeDTO?> GetJavnoNadmetanjeByIDAsync(Guid javnoNadmetanjeID, string? token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:JavnoNadmetanjeService"]}api/javnaNadmetanja/{javnoNadmetanjeID}");
            if (token != string.Empty)
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            JavnoNadmetanjeDTO? javnoNadmetanje;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                javnoNadmetanje = JsonConvert.DeserializeObject<JavnoNadmetanjeDTO?>(responseContent);
            }
            else
                javnoNadmetanje = null;

            if (javnoNadmetanje != null && javnoNadmetanje.ID != Guid.Empty)
                return javnoNadmetanje;
            else
                return null;
        }
    }
}
