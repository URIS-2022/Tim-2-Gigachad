using AutoMapper;
using KupacService.DTO;
using KupacService.Entities;

namespace KupacService.Data
{
    /// <summary>
    /// Repozitorijum za entitet kupac.
    /// </summary>
    public class KupacRepository : IKupacRepository
    {
        private readonly KupacContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za repozitorijum.
        /// </summary>
        public KupacRepository(KupacContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu kupaca iz konteksta.
        /// </summary>
        /// <returns>Vraća listu kupaca.</returns>
        public List<KupacEntity> GetKupci()
        {
            return context.Kupci.ToList();
        }

        /// <summary>
        /// Dodaje novog kupca u kontekst, kojeg kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="kupacCreateDTO">ID kupca.</param>
        /// <returns>Vraća kupca.</returns>
        public KupacDTO CreateKupac(KupacCreateDTO kupacCreateDTO)
        {
            KupacEntity kupac = mapper.Map<KupacEntity>(kupacCreateDTO);
            kupac.KupacID = Guid.NewGuid();
            context.Add(kupac);
            return mapper.Map<KupacDTO>(kupac);
        }

        /// <summary>
		/// Briše kupca iz konteksta.
		/// </summary>
		/// <param name="kupacID">ID kupca.</param>
        public void DeleteKupac(Guid kupacID)
        {
            KupacEntity? kupac = GetKupacByID(kupacID);
            if (kupac != null)
                context.Remove(kupac);
        }

        /// <summary>
		/// Vraća jednog kupca iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kupacID">ID kupca.</param>
		/// <returns>Vraća specifiranog kupca.</returns>
        public KupacEntity? GetKupacByID(Guid kupacID)
        {
            return context.Kupci.FirstOrDefault(e => e.KupacID == kupacID);
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
