using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.ServiceCalls;

namespace OvlascenoLiceService.Controllers
{
    /// <summary>
    /// Kontroler za entitet ovlasceno lice.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/ovlascenaLica")]
    [Produces("application/json", "application/xml")]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IOvlascenoLiceRepository ovlascenoLiceRepository;
        private readonly IFizickoLiceRepository fizickoLiceRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IAdresaService adresaService;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, IAdresaService adresaService)
        {
            this.ovlascenoLiceRepository = ovlascenoLiceRepository;
            this.fizickoLiceRepository = fizickoLiceRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.adresaService = adresaService;
        }

        /// <summary>
        /// Vraća listu svih ovlascenih lica.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih ovlascenih lica.</returns>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu ovlasccenih lica.</response>
        /// <response code="204">Ne postoje ovlascena lica.</response>
        //[HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OvlascenoLiceDTO>> GetLica([FromHeader] string authorization)
        {
            List<OvlascenoLiceEntity> ovlascenaLica = ovlascenoLiceRepository.GetOvlascenaLica();
            if (ovlascenaLica == null || ovlascenaLica.Count == 0)
                return NoContent();

            List<OvlascenoLiceDTO> ovlascenaLicaDTO = new();
            foreach (OvlascenoLiceEntity ovlascenoLice in ovlascenaLica)
            {
                Guid adresaID = ovlascenoLice.AdresaID;
                OvlascenoLiceDTO ovlascenoLiceDTO = mapper.Map<OvlascenoLiceDTO>(ovlascenoLice);
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                if (adresaDTO != null)
                {
                    ovlascenoLiceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(ovlascenoLice.FizickoLiceID));
                    //if (lice.PravnoLiceID != null && lice.PravnoLiceID != Guid.Empty)
                    //{
                    //    PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID((Guid)lice.PravnoLiceID);
                    //    if (pravnoLice != null)
                    //    {
                    //        liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
                    //        KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
                    //        liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
                    //    }
                    //}
                    ovlascenoLiceDTO.Adresa = adresaDTO;
                    ovlascenaLicaDTO.Add(ovlascenoLiceDTO);
                }
            }

            return Ok(ovlascenaLicaDTO);
        }
    }
}
