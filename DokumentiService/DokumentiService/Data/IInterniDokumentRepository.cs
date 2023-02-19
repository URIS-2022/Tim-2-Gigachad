using DokumentiService.DTO;
using DokumentiService.Entities;
namespace DokumentiService.Data
{
    /// <summary>
    /// Interfejs za repozitorijum internog dokumenta
    /// </summary>
    public interface IInterniDokumentRepository
    {
        /// <summary>
        /// Vraca sva interna dokumenta
        /// </summary>
        /// <returns></returns>
        List<InterniDokumentEntity> GetInterniDokument();
        /// <summary>
        /// Vraca jedan interni dokument sa zadatim ID
        /// </summary>
        /// <param name="InterniDokumentID"></param>
        /// <returns></returns>
        InterniDokumentEntity? GetInterniDokumentID(Guid InterniDokumentID);
        /// <summary>
        /// Kreira jedan interni dokument sa zadatim ID
        /// </summary>
        /// <param name="InterniDokumentDTO"></param>
        /// <returns></returns>
        InterniDokumentDTO CreateInterniDokument(InterniDokumentCreateDTO InterniDokumentDTO);
        /// <summary>
        /// Brise jedan interni dokument sa zadatim ID
        /// </summary>
        /// <param name="InterniDokumentID"></param>
        void DeleteInterniDokument(Guid InterniDokumentID);
        /// <summary>
        /// Cuva sve promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

    }
}