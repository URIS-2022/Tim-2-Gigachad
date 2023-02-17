using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;
using AutoMapper;

namespace OvlascenoLiceService.Data
{
    /// <summary>
    /// Repozitorijum za entitet lice.
    /// </summary>
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {
        private readonly OvlascenoLiceContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za repozitorijum.
        /// </summary>
        public OvlascenoLiceRepository(OvlascenoLiceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu ovlascenih lica iz konteksta.
        /// </summary>
        /// <returns>Vraća listu lica.</returns>
        public List<OvlascenoLiceEntity> GetOvlascenaLica()
        {
            return context.OvlascenaLica.ToList();
        }

        /// <summary>
        /// Vraća jedno ovlascno lice iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenog lica.</param>
        /// <returns>Vraća specifirano ovlasceno lice.</returns>
        public OvlascenoLiceEntity? GetOvlascenoLiceByID(Guid ovlascenoLiceID)
        {
            return context.OvlascenaLica.FirstOrDefault(e => e.ID == ovlascenoLiceID);
        }

        /// <summary>
        /// Dodaje novo ovlasceno lice u kontekst.
        /// </summary>
        /// <param name="ovlascenoLiceCreateDTO">DTO za kreiranje ovlascenog lica.</param>
        /// <returns>Vraća DTO kreiranog lica.</returns>
        public OvlascenoLiceDTO CreateOvlascenoLice(OvlascenoLiceCreateDTO ovlascenoLiceCreateDTO)
        {
            OvlascenoLiceEntity ovlascenoLice = mapper.Map<OvlascenoLiceEntity>(ovlascenoLiceCreateDTO);
            ovlascenoLice.ID = Guid.NewGuid();
            context.Add(ovlascenoLice);
            return mapper.Map<OvlascenoLiceDTO>(ovlascenoLice);
        }

        /// <summary>
        /// Briše ovlasceno lice iz konteksta.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenoglica.</param>
        public void DeleteOvlascenoLice(Guid ovlascenoLiceID)
        {
            OvlascenoLiceEntity? lice = GetOvlascenoLiceByID(ovlascenoLiceID);
            if (lice != null)
                context.Remove(lice);
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
