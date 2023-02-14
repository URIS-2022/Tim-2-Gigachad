using AdresaService.DTO;
using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Data
{
    /// <summary>
	/// Repozitorijum za entitet adresa.
	/// </summary>
    public class AdresaRepository : IAdresaRepository
    {
        private readonly AdresaContext context;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
        public AdresaRepository(AdresaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu adresa iz konteksta.
		/// </summary>
		/// <returns>Vraća listu adresa.</returns>
        public List<AdresaEntity> GetAdrese()
        {
            return context.Adresa.ToList();
        }

        /// <summary>
		/// Vraća jedno fizičko lice iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="adresaID">ID fizičkog lica.</param>
		/// <returns>Vraća specifirano fizičko lice.</returns>
		public AdresaEntity? GetAdresaByID(Guid adresaID)
        {
            return context.Adresa.FirstOrDefault(e => e.ID == adresaID);
        }

        /// <summary>
        /// Dodaje novo fizičko lice u kontekst, koje kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="adresaCreateDTO">DTO za kreiranje fizičkog lica.</param>
        /// <returns>Vraća DTO kreiranog fizičkog lica.</returns>
        public AdresaDTO CreateAdresa(AdresaCreateDTO adresaCreateDTO)
        {
            AdresaEntity adresa = mapper.Map<AdresaEntity>(adresaCreateDTO);
            adresa.ID = Guid.NewGuid();
            context.Add(adresa);
            return mapper.Map<AdresaDTO>(adresa);
        }

        /// <summary>
        /// Briše fizičko lice iz konteksta.
        /// </summary>
        /// <param name="adresaID">ID fizičkog lica.</param>
        public void DeleteAdresa(Guid adresaID)
        {
            AdresaEntity? adresa = GetAdresaByID(adresaID);
            if (adresa != null)
                context.Remove(adresa);
        }

        /// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
