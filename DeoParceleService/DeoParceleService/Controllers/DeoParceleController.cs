using AutoMapper;
using DeoParceleService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeoParceleService.Controllers
{
	/// <summary>
	/// Kontroler za entitet deo parcele.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/deoParcele")]
	[Produces("application/json", "application/xml")]
	public class DeoParceleController : ControllerBase
	{
		private readonly IParcelaRepository parcelaRepository;
		private readonly IDeoParceleRepository deoParceleRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public DeoParceleController(IParcelaRepository parcelaRepository, IDeoParceleRepository deoParceleRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.parcelaRepository = parcelaRepository;
			this.deoParceleRepository = deoParceleRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom deo parcele.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetParceleOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
