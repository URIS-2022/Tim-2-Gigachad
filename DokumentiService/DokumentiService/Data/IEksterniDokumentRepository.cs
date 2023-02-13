using DokumentiService.Entities;
namespace DokumentService.Data
{
    public interface IEksterniDokumentRepository
    {
        List<EksterniDokumentEntity> GetEksterniDokument();

        EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID);
        EksterniDokumentEntity CreateEksterniDokument(EksterniDokumentEntity EksterniDokument);
        void DeleteEksterniDokument(Guid EksterniDokumentID);
        void UpdateEksterniDokument(EksterniDokumentEntity EksterniDokument);
        bool SaveChanges();

    }
}