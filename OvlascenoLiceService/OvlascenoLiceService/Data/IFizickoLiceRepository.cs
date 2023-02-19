using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Data
{
    /// <summary>
    /// Interfejs od repozitorijuma za entitet fizičko lice.
    /// </summary>
    public interface IFizickoLiceRepository
    {
        /// <summary>
        /// Vraća listu fizičkih lica iz konteksta.
        /// </summary>
        /// <returns>Vraća listu fizičkih lica.</returns>
        List<FizickoLiceEntity> GetFizickaLica();

        /// <summary>
        /// Vraća jedno fizičko lice iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="fizickoLiceID">ID fizičkog lica.</param>
        /// <returns>Vraća specifirano fizičko lice.</returns>
        FizickoLiceEntity? GetFizickoLiceByID(Guid fizickoLiceID);

        /// <summary>
        /// Dodaje novo fizičko lice u kontekst.
        /// </summary>
        /// <param name="fizickoLiceCreateDTO">DTO za kreiranje fizičkog lica.</param>
        /// <returns>Vraća DTO kreiranog fizičkog lica.</returns>
        FizickoLiceDTO CreateFizickoLice(FizickoLiceCreateDTO fizickoLiceCreateDTO);

        /// <summary>
        /// Briše fizičko lice iz konteksta.
        /// </summary>
        /// <param name="fizickoLiceID">ID fizičkog lica.</param>
        void DeleteFizickoLice(Guid fizickoLiceID);

        /// <summary>
        /// Sačuva sve promene u kontekstu.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        bool SaveChanges();
    }
}
