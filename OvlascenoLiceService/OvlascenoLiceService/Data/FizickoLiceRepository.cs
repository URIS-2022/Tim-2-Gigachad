using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;
using AutoMapper;

namespace OvlascenoLiceService.Data
{
    /// <summary>
    /// Repozitorijum za entitet fizičko lice.
    /// </summary>
    public class FizickoLiceRepository : IFizickoLiceRepository
    {
        private readonly OvlascenoLiceContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za repozitorijum.
        /// </summary>
        public FizickoLiceRepository(OvlascenoLiceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu fizičkih lica iz konteksta.
        /// </summary>
        /// <returns>Vraća listu fizičkih lica.</returns>
        public List<FizickoLiceEntity> GetFizickaLica()
        {
            return context.FizickaLica.ToList();
        }

        /// <summary>
        /// Vraća jedno fizičko lice iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="fizickoLiceID">ID fizičkog lica.</param>
        /// <returns>Vraća specifirano fizičko lice.</returns>
        public FizickoLiceEntity? GetFizickoLiceByID(Guid fizickoLiceID)
        {
            return context.FizickaLica.FirstOrDefault(e => e.ID == fizickoLiceID);
        }

        /// <summary>
        /// Dodaje novo fizičko lice u kontekst.
        /// </summary>
        /// <param name="fizickoLiceCreateDTO">DTO za kreiranje fizičkog lica.</param>
        /// <returns>Vraća DTO kreiranog fizičkog lica.</returns>
        public FizickoLiceDTO CreateFizickoLice(FizickoLiceCreateDTO fizickoLiceCreateDTO)
        {
            FizickoLiceEntity fizickoLice = mapper.Map<FizickoLiceEntity>(fizickoLiceCreateDTO);
            fizickoLice.ID = Guid.NewGuid();
            context.Add(fizickoLice);
            return mapper.Map<FizickoLiceDTO>(fizickoLice);
        }

        /// <summary>
        /// Briše fizičko lice iz konteksta.
        /// </summary>
        /// <param name="fizickoLiceID">ID fizičkog lica.</param>
        public void DeleteFizickoLice(Guid fizickoLiceID)
        {
            FizickoLiceEntity? fizickoLice = GetFizickoLiceByID(fizickoLiceID);
            if (fizickoLice != null)
                context.Remove(fizickoLice);
        }

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
