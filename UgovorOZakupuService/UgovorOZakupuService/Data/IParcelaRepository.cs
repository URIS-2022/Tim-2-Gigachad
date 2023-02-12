using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public interface IParcelaRepository 
    {
        List<ParcelaEntity> GetParcela();

        ParcelaEntity GetParcelabyID (Guid parcelaID);

        ParcelaEntity CreateParcela (ParcelaEntity parcela);

        void UpdateParcela(ParcelaEntity parcela);

        void DeleteParcela (Guid parcelaID);

        bool SaveChanges();
    }
}
