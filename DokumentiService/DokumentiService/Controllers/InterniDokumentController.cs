﻿using AutoMapper;
using DokumentiService.Data;
using DokumentiService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DokumentiService.Controllers
{
    /// <summary>
    /// Kontroler za entitete eksternih dokumenata.
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/interniDokumenti")]
    [Produces("application/json", "application/xml")]
    public class InterniDokumentController : ControllerBase
    {
        private readonly IInterniDokumentRepository interniDokumentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public InterniDokumentController(IInterniDokumentRepository interniDokumentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.interniDokumentRepository = interniDokumentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<EksterniDokumentEntity>> GetInterniDokumenti()
        {
            var intdok = interniDokumentRepository.GetInterniDokument();
            if (intdok == null || intdok.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<InterniDokumentEntity>>(intdok));
        }
    }
}

