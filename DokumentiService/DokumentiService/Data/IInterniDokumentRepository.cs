using DokumentiService.Entities;
namespace DokumentService.Data
{
    public interface IInterniDokumentRepository
    {
        List<InterniDokumentEntity> GetInterniDokument();

        InterniDokumentEntity GetDokumentID(Guid InterniDokumentID);
        InterniDokumentEntity CreateDokument(DokumentEntity InterniDokument);
        void DeleteInterniDokument(Guid InterniDokumentID);
        void UpdateInterniDokument(DokumentEntity InterniDokument);
        bool SaveChanges();

    }
}