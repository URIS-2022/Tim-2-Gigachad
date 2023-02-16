using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    /// <summary>
    /// Repozitorijum za entitet žalba.
    /// </summary>
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly ZalbaContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za repozitorijum.
        /// </summary>
        public ZalbaRepository(ZalbaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu žalbi iz konteksta.
        /// </summary>
        /// <returns>Vraća listu žalbi.</returns>
        public List<ZalbaEntity> GetZalbe()
        {
            return context.Zalbe.ToList();
        }

        /// <summary>
        /// Dodaje novu žalbu u kontekst, koje kasnije vraća kao DTO objekat.
        /// </summary>
        /// <param name="zalbaCreateDTO">DTO za kreiranje žalbe.</param>
        /// <returns>Vraća DTO kreirane žalbe.</returns>
        public ZalbaDTO CreateZalba(ZalbaCreateDTO zalbaCreateDTO)
        {
            ZalbaEntity zalba = mapper.Map<ZalbaEntity>(zalbaCreateDTO);
            zalba.ZalbaID = Guid.NewGuid();
            context.Add(zalba);
            return mapper.Map<ZalbaDTO>(zalba);
        }

        /// <summary>
        /// Briše žalbu iz konteksta.
        /// </summary>
        /// <param name="zalbaID">ID žalbe.</param>
        public void DeleteZalba(Guid zalbaID)
        {
            ZalbaEntity? zalba = GetZalbaByID(zalbaID);
            if (zalba != null)
                context.Remove(zalba);
        }

        /// <summary>
        /// Vraća jednu žalbu iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="zalbaID">ID žalbe.</param>
        /// <returns>Vraća specifiranu žalbu.</returns>
        public ZalbaEntity? GetZalbaByID(Guid zalbaID)
        {
            return context.Zalbe.FirstOrDefault(e => e.ZalbaID == zalbaID);
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
