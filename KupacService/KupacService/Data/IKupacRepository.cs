using KupacService.DTO;
using KupacService.Entities;

namespace KupacService.Data
{
    /// <summary>
    /// Interfejs repozitorijuma entiteta kupca.
    /// </summary>
    public interface IKupacRepository
    {
        /// <summary>
        /// Vraća listu kupaca iz konteksta.
        /// </summary>
        /// <returns>Vraća listu kupaca.</returns>
        List<KupacEntity> GetKupci();

        /// <summary>
        /// Vraća jednog kupca iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="kupacID">ID lica kupca.</param>
        /// <returns>Vraća specifiranog kupca.</returns>
        KupacEntity? GetKupacByID(Guid kupacID);

        /// <summary>
        /// Dodaje novog kupca u kontekst.
        /// </summary>
        /// <param name="kupacCreateDTO">DTO za kreiranje kupca.</param>
        /// <returns>Vraća DTO kreiranog kupca.</returns>
        KupacDTO CreateKupac(KupacCreateDTO kupacCreateDTO);

        /// <summary>
        /// Briše kupca iz konteksta.
        /// </summary>
        /// <param name="kupacID">ID kupca.</param>
        void DeleteKupac(Guid kupacID);

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        bool SaveChanges();
    }
}
