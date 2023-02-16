using UgovorOZakupuService.Entities;
using AutoMapper;

namespace UgovorOZakupuService.Data
{
    public class UgovorOZakupuRepository : IUgovorOZakupuRepository
    {
        private readonly UgovorOZakupuContext context;
        private readonly IMapper mapper;

        public UgovorOZakupuRepository(UgovorOZakupuContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<UgovorOZakupuEntity> GetUgovorOZakupu()
        {
            return context.Ugovori.ToList();
        }

        public UgovorOZakupuEntity GetUgovorOZakupuID(Guid UgovorOZakupuID)
        {
            return null;
        }

        public UgovorOZakupuEntity CreateUgovorOZakupu(UgovorOZakupuEntity UgovorOZakupu)
        {
            return null;
        }

        public void DeleteUgovorOZakupu(Guid UgovorOZakupuID)
        {
            
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }

  
}
