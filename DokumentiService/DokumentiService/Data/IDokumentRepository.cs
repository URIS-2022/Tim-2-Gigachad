using DokumentiService.Entities;
using DokumentiService.DTO;
namespace DokumentiService.Data
{
    /// <summary>
    /// Interfejs od dokument repozitorijuma
    /// </summary>
    public interface IDokumentRepository
    {
        /// <summary>
        /// Vraca listu svih dokumenata
        /// </summary>
        /// <returns></returns>
        List<DokumentEntity> GetDokument();
        /// <summary>
        /// Vraca jedan dokument sa ID
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <returns></returns>
        DokumentEntity GetDokumentID(Guid DokumentID);
        /// <summary>
        /// Kreira dokument
        /// </summary>
        /// <param name="DokumentCreateDTO"></param>
        /// <returns></returns>
        DokumentDTO CreateDokument(DokumentCreateDTO DokumentCreateDTO);
        /// <summary>
        /// Brise dokument sa ID
        /// </summary>
        /// <param name="DokumentID"></param>
        void DeleteDokument(Guid DokumentID);
        /// <summary>
        /// Cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

    }
}
