using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;
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

        public UgovorOZakupuDTO CreateUgovorOZakupu(UgovorOZakupuCreateDTO UgovorOZakupuCreateDTO)
        {
            UgovorOZakupuEntity Ugovor = mapper.Map<UgovorOZakupuEntity>(UgovorOZakupuCreateDTO);
            Ugovor.UgovorOZakupuID = Guid.NewGuid();
            context.Add(Ugovor);
            return mapper.Map<UgovorOZakupuDTO>(Ugovor);
        }

        public void DeleteUgovorOZakupu(Guid UgovorOZakupuID)
        {
            UgovorOZakupuEntity Ugovor = GetUgovorOZakupuID(UgovorOZakupuID);
            if (Ugovor != null)
                context.Remove(Ugovor);
        }

        public List<UgovorOZakupuEntity> GetUgovorOZakupu()
        {
            return context.Ugovori.ToList();
        }

        public UgovorOZakupuEntity GetUgovorOZakupuID(Guid UgovorOZakupuID)
        {
            return context.Ugovori.FirstOrDefault(e => e.UgovorOZakupuID == UgovorOZakupuID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
