using AutoMapper;
using LiceService.Data;
using LiceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	//[Authorize]
	[ApiController]
	[Route("api/fizickaLica")]
	[Produces("application/json", "application/xml")]
	public class FizickoLiceController : ControllerBase
	{
		private readonly IFizickoLiceRepository fizickoLiceRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;
		
		public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.fizickoLiceRepository = fizickoLiceRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		[HttpGet]
		[HttpHead]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<FizickoLiceDTO>> GetFizickaLica()
		{
			//List<FizickoLiceDTO>
			//return Ok("seses");
			var fizickaLica = fizickoLiceRepository.GetFizickaLica();
			if (fizickaLica == null || fizickaLica.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<FizickoLiceDTO>>(fizickaLica));
			//return Ok(fizickaLica);
		}
	}
}
