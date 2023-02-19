using DokumentiService.Entities;
using DokumentiService.DTO;
namespace DokumentiService.Data
{
    /// <summary>
    /// Interfejs za repozitorijum eksternog dokumenta
    /// </summary>
    public interface IEksterniDokumentRepository
    {
        /// <summary>
        /// Vraca sva eksterna dokumenta
        /// </summary>
        /// <returns></returns>
        List<EksterniDokumentEntity> GetEksterniDokument();
        /// <summary>
        /// Vraca eksterni dokumetn sa zadati ID
        /// </summary>
        /// <param name="EksterniDokumentID"></param>
        /// <returns></returns>
        EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID);
        /// <summary>
        /// Kreira eksterni Dokument sa zadatim ID
        /// </summary>
        /// <param name="EksterniDokumentDTO"></param>
        /// <returns></returns>
        EksterniDokumentDTO CreateEksterniDokument(EksterniDokumentCreateDTO EksterniDokumentDTO);
        /// <summary>
        /// Brise eksterni dokument sa zadatim ID
        /// </summary>
        /// <param name="EksterniDokumentID"></param>
        void DeleteEksterniDokument(Guid EksterniDokumentID);
        /// <summary>
        /// Cuva sve promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

    }
}