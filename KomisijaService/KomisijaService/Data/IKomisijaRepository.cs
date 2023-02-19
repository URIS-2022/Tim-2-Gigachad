using KomisijaService.Entities;
using KomisijaService.Models;

namespace KomisijaService.Data
{
    /// <summary>
    /// Interfejs od repozitorijuma za entitet komsija.
    /// </summary>
    public interface IKomisijaRepository
    {
        /// <summary>
        /// Vraća listu komsija iz konteksta.
        /// </summary>
        /// <returns>Vraća listu komisija.</returns>
        List<KomisijaEntity> GetKomisije();

        /// <summary>
        /// Vraća jednu komisiju iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="komisijaID">ID komisije.</param>
        /// <returns>Vraća specificiranu komisiju.</returns>
        KomisijaEntity? GetKomisijaByID(Guid komisijaID);

        /// <summary>
        /// Dodaje novu komisiju u kontekst, koje kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="komisija">DTO za kreiranje komisije.</param>
        /// <returns>Vraća DTO kreirane komisije.</returns>
        KomisijaDTO CreateKomisija(KomisijaCreateDTO komisija);

        /// <summary>
        /// Briše komisiju iz konteksta.
        /// </summary>
        /// <param name="komisijaID">ID komisije.</param>
        void DeleteKomisija(Guid komisijaID);

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena</returns>
        bool SaveChanges();
    }
}
