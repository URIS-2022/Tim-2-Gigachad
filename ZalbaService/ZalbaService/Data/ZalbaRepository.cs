using AutoMapper;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly ZalbaContext context;
        private readonly IMapper mapper;

        public ZalbaRepository(ZalbaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ZalbaEntity> GetZalbe()
        {
            return context.Zalbe.ToList();
        }

        public ZalbaEntity CreateZalba(ZalbaEntity zalba)
        {
            return null;
        }

        public void DeleteZalba(Guid zalbaID)
        {

        }

        public ZalbaEntity GetZalbaByID(Guid zalbaID)
        {
            return null;
        }

        public void UpdateZalba(ZalbaEntity zalba)
        {
            
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
