using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Data
{
    /// <summary>
	/// Repozitorijum za entitet javno nadmetanje.
	/// </summary>
    ///
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
        public JavnoNadmetanjeRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu javnih nadmetanja iz konteksta.
		/// </summary>
		/// <returns>Vraća listu javnih nadmetanja.</returns>
        public List<JavnoNadmetanjeEntity> GetJavnaNadmetanja()
        {
            return context.JavnoNadmetanje.ToList();
        }

        /// <summary>
		/// Vraća jedno javno nadmetanje iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <returns>Vraća specifiranog javno nadmetanje.</returns>
        public JavnoNadmetanjeEntity? GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID)
        {
            return context.JavnoNadmetanje.FirstOrDefault(e => e.ID == javnoNadmetanjeID);
        }

        /// <summary>
		/// Dodaje novo javno nadmetanje u kontekst.
		/// </summary>
		/// <param name="javnoNadmetanjeCreateDTO">DTO za kreiranje javnog nadmetanja.</param>
		/// <returns>Vraća DTO kreiranog javnog nadmetanja.</returns>
        public JavnoNadmetanjeDTO CreateJavnoNadmetanje(JavnoNadmetanjeCreateDTO javnoNadmetanjeCreateDTO)
        {
            JavnoNadmetanjeEntity javnoNadmetanje = mapper.Map<JavnoNadmetanjeEntity>(javnoNadmetanjeCreateDTO);
            javnoNadmetanje.ID = Guid.NewGuid();
            context.Add(javnoNadmetanje);
            return mapper.Map<JavnoNadmetanjeDTO>(javnoNadmetanje);
        }

        /// <summary>
        /// Briše javno nadmetanje iz konteksta.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
        public void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
            JavnoNadmetanjeEntity? javnoNadmetanje = GetJavnoNadmetanjeByID(javnoNadmetanjeID);
            if (javnoNadmetanje != null)
                context.Remove(javnoNadmetanje);
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
