using UgovorOZakupuService.Entities;
namespace UgovorOZakupuService.Data
{
    public interface IUgovorOZakupuRepository
    {
        List<UgovorOZakupuEntity> GetUgovorOZakupu();

        UgovorOZakupuEntity GetUgovorOZakupuID(Guid UgovorOZakupuID);
        UgovorOZakupuEntity CreateUgovorOZakupu(UgovorOZakupuEntity UgovorOZakupu);
        void DeleteUgovorOZakupu(Guid UgovorOZakupuID);
        void UpdateUgovorOZakupu(UgovorOZakupuEntity UgovorOZakupu);
        bool SaveChanges();

    }
}
