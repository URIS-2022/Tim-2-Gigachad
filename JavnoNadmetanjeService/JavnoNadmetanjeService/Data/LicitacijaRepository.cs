using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace LicitacijaService.Data
{
    /// <summary>
	/// Repozitorijum za entitet licitacije.
	/// </summary>
    public class LicitacijaRepository : ILicitacijaRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
        public LicitacijaRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu licitacija iz konteksta.
		/// </summary>
		/// <returns>Vraća listu licitacija.</returns>
        public List<LicitacijaEntity> GetLicitacije()
        {
            return context.Licitacija.ToList();
        }

        /// <summary>
		/// Vraća jednu licitaciju iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="licitacijaID">ID licitacije.</param>
		/// <returns>Vraća specifiranu licitaciju.</returns>
        public LicitacijaEntity? GetLicitacijaByID(Guid licitacijaID)
        {
            return context.Licitacija.FirstOrDefault(e => e.ID == licitacijaID);
        }

        /// <summary>
        /// Dodaje novu licitaciju u kontekst, koja kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="licitacijaCreateDTO">DTO za kreiranje licitacije.</param>
        /// <returns>Vraća DTO kreirane licitacije.</returns>
        public LicitacijaDTO CreateLicitacija(LicitacijaCreateDTO licitacijaCreateDTO)
        {
            LicitacijaEntity licitacija = mapper.Map<LicitacijaEntity>(licitacijaCreateDTO);
            licitacija.ID = Guid.NewGuid();
            context.Add(licitacija);
            return mapper.Map<LicitacijaDTO>(licitacija);
        }

        /// <summary>
        /// Briše licitaciju iz konteksta.
        /// </summary>
        /// <param name="licitacijaID">ID licitacije.</param>
        public void DeleteLicitacija(Guid licitacijaID)
        {
            LicitacijaEntity? licitacija = GetLicitacijaByID(licitacijaID);
            if (licitacija != null)
                context.Remove(licitacija);
        }

        /// <summary>
		/// Cuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sacuvanih promena.</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
