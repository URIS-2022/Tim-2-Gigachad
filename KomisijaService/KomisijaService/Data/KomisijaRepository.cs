using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.Models;

namespace KomisijaService.Data
{
    /// <summary>
    /// Repozitorijum za entitet komisija.
    /// </summary>
    public class KomisijaRepository : IKomisijaRepository
    { 
        private readonly KomisijaContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za repozitorijum.
        /// </summary>
        public KomisijaRepository(KomisijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu komisija iz konteksta.
        /// </summary>
        /// <returns>Vraća listu komisija.</returns>
        public List<KomisijaEntity> GetKomisije() {
            return context.Komisije.ToList();
        }

        /// <summary>
        /// Dodaje novu komisiju u kontekst, koje kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="komisijaCreateDTO">DTO za kreiranje komisije.</param>
        /// <returns>Vraća DTO kreirane komisije.</returns>
        public KomisijaDTO CreateKomisija(KomisijaCreateDTO komisijaCreateDTO)
        {
            KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaCreateDTO);
            komisija.KomisijaID = Guid.NewGuid();
            context.Add(komisija);
            return mapper.Map<KomisijaDTO>(komisija);
        }

        /// <summary>
        /// Briše komisiju iz konteksta.
        /// </summary>
        /// <param name="komisijaID">ID komisije.</param>
        public void DeleteKomisija(Guid komisijaID)
        {
            KomisijaEntity? komisija = GetKomisijaByID(komisijaID);
            if (komisija != null)
                context.Remove(komisija);
        }

        /// <summary>
        /// Vraća jednu komisiju iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="komisijaID">ID komisije.</param>
        /// <returns>Vraća specifiranu komisiju.</returns>
        public KomisijaEntity? GetKomisijaByID(Guid komisijaID)
        {
            return context.Komisije.FirstOrDefault(e => e.KomisijaID == komisijaID);
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
