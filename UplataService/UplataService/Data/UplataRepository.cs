using AutoMapper;
using UplataService.Entities;

namespace UplataService.Data
{
    public class UplataRepository : IUplataRepository
    {
        private readonly UplataContext context;
        private readonly IMapper mapper;

        public UplataRepository(UplataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<UplataEntity> GetUplate()
        {
            return context.Uplate.ToList();
        }

        public UplataEntity CreateUplata(UplataEntity Uplata)
        {
            return null;
        }

        public void DeleteUplata(Guid UplataID)
        {
        }

        public UplataEntity GetUplataByID(Guid UplataID)
        {
            return null;
        }

        public void UpdateUplata(UplataEntity Uplata)
        {
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
