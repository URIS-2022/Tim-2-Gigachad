using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Interfejs od repozitorijuma za entitet žalba.
    /// </summary>
    public interface IZalbaRepository
    {
        /// <summary>
        /// Vraća listu žalbi iz konteksta.
        /// </summary>
        /// <returns>Vraća listu žalbi.</returns>
        List<ZalbaEntity> GetZalbe();

        /// <summary>
        /// Vraća jednu žalbu iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="zalbaID">ID žalbe.</param>
        /// <returns>Vraća specificiranu žalbu.</returns>
        ZalbaEntity? GetZalbaByID(Guid zalbaID);

        /// <summary>
        /// Dodaje novu žalbu u kontekst, koje kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="zalba">DTO za kreiranje žalbe.</param>
        /// <returns>Vraća DTO kreirane žalbe.</returns>
        ZalbaDTO CreateZalba(ZalbaCreateDTO zalba);

        /// <summary>
        /// Briše žalbu iz konteksta.
        /// </summary>
        /// <param name="zalbaID">ID žalbe.</param>
        void DeleteZalba(Guid zalbaID);

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena</returns>
        bool SaveChanges();
    }
}
