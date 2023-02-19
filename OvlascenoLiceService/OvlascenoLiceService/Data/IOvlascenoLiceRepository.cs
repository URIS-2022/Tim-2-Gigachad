using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Data
{
    /// <summary>
    /// Interfejs od repozitorijuma za entitet ovlasceno lice.
    /// </summary>
    public interface IOvlascenoLiceRepository
    {
        /// <summary>
        /// Vraća listu ovlascenih lica iz konteksta.
        /// </summary>
        /// <returns>Vraća listu lica.</returns>
        List<OvlascenoLiceEntity> GetOvlascenaLica();

        /// <summary>
        /// Vraća jedno ovlasceno lice iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenog lica.</param>
        /// <returns>Vraća specifirano ovlasceno lice.</returns>
        OvlascenoLiceEntity? GetOvlascenoLiceByID(Guid ovlascenoLiceID);

        /// <summary>
        /// Dodaje novo ovlasceno lice u kontekst.
        /// </summary>
        /// <param name="ovlascenoLiceCreateDTO">DTO za kreiranje ovlascenog lica.</param>
        /// <returns>Vraća DTO kreiranog ovlascenog lica.</returns>
        OvlascenoLiceDTO CreateOvlascenoLice(OvlascenoLiceCreateDTO ovlascenoLiceCreateDTO);

        /// <summary>
        /// Briše ovlasceno lice iz konteksta.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenog lica.</param>
        void DeleteOvlascenoLice(Guid ovlascenoLiceID);

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        bool SaveChanges();
    }
}
