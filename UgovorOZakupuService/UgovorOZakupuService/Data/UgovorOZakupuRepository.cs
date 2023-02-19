using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;
using AutoMapper;

namespace UgovorOZakupuService.Data
{
    /// <summary>
    /// Repozitroijum za Ugovor o zakupu
    /// </summary>
    public class UgovorOZakupuRepository : IUgovorOZakupuRepository
    {
        private readonly UgovorOZakupuContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Inicira ugovor o zakupu
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        
        public UgovorOZakupuRepository(UgovorOZakupuContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// kreira novi ugovor o zakupu
        /// </summary>
        /// <param name="UgovorOZakupuCreateDTO"></param>
        /// <returns></returns>

        public UgovorOZakupuDTO CreateUgovorOZakupu(UgovorOZakupuCreateDTO UgovorOZakupuCreateDTO)
        {
            UgovorOZakupuEntity Ugovor = mapper.Map<UgovorOZakupuEntity>(UgovorOZakupuCreateDTO);
            Ugovor.UgovorOZakupuID = Guid.NewGuid();
            context.Add(Ugovor);
            return mapper.Map<UgovorOZakupuDTO>(Ugovor);
        }
        /// <summary>
        /// menja ugovor o zakupu
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        public void DeleteUgovorOZakupu(Guid UgovorOZakupuID)
        {
            UgovorOZakupuEntity Ugovor = GetUgovorOZakupuID(UgovorOZakupuID);
            if (Ugovor != null)
                context.Remove(Ugovor);
        }

        /// <summary>
        /// Vraca ugovore o zakupu
        /// </summary>
        /// <returns></returns>
        public List<UgovorOZakupuEntity> GetUgovorOZakupu()
        {
            return context.Ugovori.ToList();
        }
        /// <summary>
        /// Vraca jedan ugovor o zakupu sa ID
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        /// <returns></returns>
        public UgovorOZakupuEntity? GetUgovorOZakupuID(Guid UgovorOZakupuID)
        {
            return context.Ugovori.FirstOrDefault(e => e.UgovorOZakupuID == UgovorOZakupuID);
        }
        /// <summary>
        /// Cuva promene
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
