using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

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

        public ZalbaDTO CreateZalba(ZalbaCreateDTO zalbaCreateDTO)
        {
            ZalbaEntity zalba = mapper.Map<ZalbaEntity>(zalbaCreateDTO);
            zalba.ZalbaID = Guid.NewGuid();
            context.Add(zalba);
            return mapper.Map<ZalbaDTO>(zalba);
        }

        public void DeleteZalba(Guid zalbaID)
        {
            ZalbaEntity? zalba = GetZalbaByID(zalbaID);
            if (zalba != null)
                context.Remove(zalba);
        }

        public ZalbaEntity? GetZalbaByID(Guid zalbaID)
        {
            return context.Zalbe.FirstOrDefault(e => e.ZalbaID == zalbaID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
