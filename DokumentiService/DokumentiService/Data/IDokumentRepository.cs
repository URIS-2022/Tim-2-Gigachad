using DokumentiService.Entities;
using DokumentiService.DTO;
namespace DokumentiService.Data
{
    public interface IDokumentRepository
    {
        List<DokumentEntity> GetDokument();

        DokumentEntity GetDokumentID(Guid DokumentID);
        DokumentDTO CreateDokument(DokumentCreateDTO DokumentCreateDTO);
        void DeleteDokument(Guid DokumentID);
        bool SaveChanges();

    }
}
