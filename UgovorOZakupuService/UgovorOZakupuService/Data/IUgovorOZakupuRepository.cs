using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;
namespace UgovorOZakupuService.Data
{
    /// <summary>
    /// Repozitorijum za ugovor o zakupu
    /// </summary>
    public interface IUgovorOZakupuRepository
    {
        /// <summary>
        /// Vraca sve ugovore
        /// </summary>
        /// <returns></returns>
        List<UgovorOZakupuEntity> GetUgovorOZakupu();
        /// <summary>
        /// Vraca ugovor o zakupu po ID
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        /// <returns></returns>
        UgovorOZakupuEntity? GetUgovorOZakupuID(Guid UgovorOZakupuID);
        /// <summary>
        /// Kreira novi ugovor o zakupu
        /// </summary>
        /// <param name="UgovorOZakupuCreateDTO"></param>
        /// <returns></returns>
        UgovorOZakupuDTO CreateUgovorOZakupu(UgovorOZakupuCreateDTO UgovorOZakupuCreateDTO);
        /// <summary>
        /// Brise ugovor o zakupu sa zadatim ID
        /// </summary>
        /// <param name="UgovorOZakupuID"></param>
        void DeleteUgovorOZakupu(Guid UgovorOZakupuID);
        /// <summary>
        /// Cuva sve greske
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

    }
}
