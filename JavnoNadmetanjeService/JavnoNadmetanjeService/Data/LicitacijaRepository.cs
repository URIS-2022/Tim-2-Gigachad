using AutoMapper;
using JavnoNadmetanjeService.Entities;

namespace LicitacijaService.Data
{
    public class LicitacijaRepository : ILicitacijaRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        public LicitacijaRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<LicitacijaEntity> GetLicitacija()
        {
            return context.Licitacija.ToList();
        }

        public LicitacijaEntity CreateLicitacija(LicitacijaEntity licitacija)
        {
            return null;
        }

        public void DeleteLicitacija(Guid licitacijaID)
        {
        }

        public LicitacijaEntity GetLicitacijaByID(Guid licitacijaID)
        {
            return null;
        }

        public void UpdateLicitacija(LicitacijaEntity licitacija)
        {
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
