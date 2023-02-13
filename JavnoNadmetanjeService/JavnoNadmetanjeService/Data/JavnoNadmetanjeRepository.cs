using AutoMapper;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Data
{
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        public JavnoNadmetanjeRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<JavnoNadmetanjeEntity> GetJavnoNadmetanje()
        {
            return context.JavnoNadmetanje.ToList();
        }

        public JavnoNadmetanjeEntity CreateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanje)
        {
            return null;
        }

        public void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
        }

        public JavnoNadmetanjeEntity GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID)
        {
            return null;
        }

        public void UpdateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanje)
        {
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
