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
		/// Vraća jednu adresu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="ID">ID adrese.</param>
		/// <returns>Vraća specifiranu adresu.</returns>
		public AdresaEntity? GetAdresaByID(Guid ID)
        {
            return context.Adresa.FirstOrDefault(e => e.ID == ID);
        }

        /// <summary>
        /// Dodaje novu adresu u kontekst, koja kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="adresaCreateDTO">DTO za kreiranje adrese.</param>
        /// <returns>Vraća DTO kreirane adrese.</returns>
        public AdresaDTO CreateAdresa(AdresaCreateDTO adresaCreateDTO)
        {
            AdresaEntity adresa = mapper.Map<AdresaEntity>(adresaCreateDTO);
            adresa.ID = Guid.NewGuid();
            context.Add(adresa);
            return mapper.Map<AdresaDTO>(adresa);
        }

        /// <summary>
        /// Briše adresu iz konteksta.
        /// </summary>
        /// <param name="adresaID">ID adrese.</param>
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
