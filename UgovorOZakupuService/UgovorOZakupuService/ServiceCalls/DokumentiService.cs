using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UgovorOZakupuService.DTO;


namespace UgovorOZakupuService.ServiceCalls
{
    /// <summary>
    /// Interfejs za dokumentiService
    /// </summary>
    public class DokumentiService : IDokumentiService
    {
        private readonly IConfiguration configuration;
        /// <summary>
        /// Dependency injection za konfiguraciju konekcije
        /// <param name="configuration"></param>
        public DokumentiService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
		/// Vraća adresu dokumenta od drugog mikro servisa.
		/// </summary>
		/// <param name="dokumentID">ID adrese dokumenta.</param>
		/// <param name="token">Token za adresu dokumenta mikroservis.</param>
		/// <returns>Vraća model DTO-a adrese dokumenta.</returns>
        public async Task<DokumentDTO?> GetDokumentByIDAsync(Guid dokumentID, string token)
        {
            using HttpClient httpClient = new();
            Uri url = new($"{configuration["Services:DokumentiService"]}api/Dokumenti/{dokumentID}");
            if (token != string.Empty)
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            DokumentDTO? dokument;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                dokument = JsonConvert.DeserializeObject<DokumentDTO?>(responseContent);
            }
            else
                dokument = null;
            if (dokument != null && dokument.DokumentID != Guid.Empty)
                return dokument;
            else
                return null;
        }
        

    }
}
