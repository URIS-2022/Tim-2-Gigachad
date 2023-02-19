using DokumentiService.Entities;
using DokumentiService.DTO;
namespace DokumentiService.Data
{
    public interface IEksterniDokumentRepository
    {
        List<EksterniDokumentEntity> GetEksterniDokument();
        EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID);
        EksterniDokumentDTO CreateEksterniDokument(EksterniDokumentCreateDTO EksterniDokumentDTO);
        void DeleteEksterniDokument(Guid EksterniDokumentID);
        bool SaveChanges();

    }
}