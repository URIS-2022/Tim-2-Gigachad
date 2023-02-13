using DokumentiService.Entities;
namespace DokumentService.Data
{
    public interface IDokumentRepository
    {
        List<DokumentEntity> GetDokument();

        DokumentEntity GetDokumentID(Guid DokumentID);
        DokumentEntity CreateDokument(DokumentEntity Dokument);
        void DeleteDokument(Guid DokumentID);
        void UpdateDokument(DokumentEntity Dokument);
        bool SaveChanges();

    }
}
