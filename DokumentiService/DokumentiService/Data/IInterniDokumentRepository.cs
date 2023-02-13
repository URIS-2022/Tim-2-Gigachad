using DokumentiService.Entities;
namespace DokumentiService.Data
{
    public interface IInterniDokumentRepository
    {
        List<InterniDokumentEntity> GetInterniDokument();

        InterniDokumentEntity GetInterniDokumentID(Guid InterniDokumentID);
        InterniDokumentEntity CreateInterniDokument(InterniDokumentEntity InterniDokument);
        void DeleteInterniDokument(Guid InterniDokumentID);
        void UpdateInterniDokument(DokumentEntity InterniDokument);
        bool SaveChanges();

    }
}