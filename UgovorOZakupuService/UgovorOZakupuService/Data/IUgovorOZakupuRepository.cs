using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;
namespace UgovorOZakupuService.Data
{
    public interface IUgovorOZakupuRepository
    {
        List<UgovorOZakupuEntity> GetUgovorOZakupu();
        UgovorOZakupuEntity GetUgovorOZakupuID(Guid UgovorOZakupuID);
        UgovorOZakupuDTO CreateUgovorOZakupu(UgovorOZakupuCreateDTO UgovorOZakupuCreateDTO);
        void DeleteUgovorOZakupu(Guid UgovorOZakupuID);
        bool SaveChanges();

    }
}
