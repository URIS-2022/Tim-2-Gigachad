using AutoMapper;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    /// <summary>
	/// Repozitorijum za entitet uplata.
	/// </summary>
    public class UplataRepository : IUplataRepository
    {
        private readonly UplataContext context;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
        public UplataRepository(UplataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu uplata iz konteksta.
		/// </summary>
		/// <returns>Vraća listu uplata.</returns>
        public List<UplataEntity> GetUplate()
        {
            return context.Uplate.ToList();
        }

        /// <summary>
		/// Dodaje novu uplatu u kontekst, koju kasnije vraća kao DTO objekat.
		/// </summary>
		/// <param name="UplataCreateDTO">DTO za kreiranje uplate.</param>
		/// <returns>Vraća DTO kreirane uplate.</returns>
        public UplataDTO CreateUplata(UplataCreateDTO UplataCreateDTO)
        {
            UplataEntity uplata = mapper.Map<UplataEntity>(UplataCreateDTO);
            uplata.UplataID = Guid.NewGuid();
            context.Add(uplata);
            return mapper.Map<UplataDTO>(uplata);
        }

        /// <summary>
		/// Briše uplatu iz konteksta.
		/// </summary>
		/// <param name="UplataID">ID uplate.</param>
        public void DeleteUplata(Guid UplataID)
        {
            UplataEntity? uplata = GetUplataByID(UplataID);
            if (uplata != null)
                context.Remove(uplata);
        }

        /// <summary>
		/// Vraća jednu uplatu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="UplataID">ID uplate.</param>
		/// <returns>Vraća specifiranu uplatu.</returns>
        public UplataEntity GetUplataByID(Guid UplataID)
        {
            return context.Uplate.FirstOrDefault(e => e.UplataID == UplataID);
        }

        public void UpdateUplata(UplataEntity Uplata)
        {
        }

        /// <summary>
		/// U kontekstu sačuva sve promene i onda vraća boolean na osnovu da li je sačuvano ili ne.
		/// </summary>
		/// <returns>Vraća boolean.</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
