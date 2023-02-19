using DokumentiService.DTO;
using DokumentiService.Entities;
namespace DokumentiService.Data
{
    public interface IInterniDokumentRepository
    {
        List<InterniDokumentEntity> GetInterniDokument();

        InterniDokumentEntity GetInterniDokumentID(Guid InterniDokumentID);
        InterniDokumentDTO CreateInterniDokument(InterniDokumentCreateDTO InterniDokumentDTO);
        void DeleteInterniDokument(Guid InterniDokumentID);
        bool SaveChanges();

    }
}