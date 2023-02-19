using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

namespace DokumentiService.Data
{
    /// <summary>
    /// Repozitorijum za interni dokument Entity
    /// </summary>
    public class InterniDokumentRepository : IInterniDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// Inicira dokument repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public InterniDokumentRepository(DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira novi interni Dokument
        /// </summary>
        /// <param name="interniDokumentCreateDTO"></param>
        /// <returns>Vraća DTO internog dokumenta</returns>
        public InterniDokumentDTO CreateInterniDokument(InterniDokumentCreateDTO interniDokumentCreateDTO)
        {
            InterniDokumentEntity intdok = mapper.Map<InterniDokumentEntity>(interniDokumentCreateDTO);
            intdok.InterniDokumentID = Guid.NewGuid();
            context.Add(intdok);
            return mapper.Map<InterniDokumentDTO>(intdok);
        }
        /// <summary>
        /// Brise zadati interni dokument
        /// </summary>
        /// <param name="InterniDokumentID"></param>
        public void DeleteInterniDokument(Guid InterniDokumentID)
        {
            InterniDokumentEntity? interniDokument = GetInterniDokumentID(InterniDokumentID);
            if (interniDokument != null)
                context.Remove(interniDokument);

        }
        /// <summary>
        /// Vraća listu internih dokumenata iz konteksta.
        /// </summary>
        /// <returns>Vraća listu internih dokumenata.</returns>

        public List<InterniDokumentEntity> GetInterniDokument()
        {
            return context.InterniDokumenti.ToList();
        }

        /// <summary>
        /// Vraća jedan interni dokument iz konteksta na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="InterniDokumentID">ID dokumenta.</param>
        /// <returns>Vraća specificiran interni dokument.</returns>
        public InterniDokumentEntity? GetInterniDokumentID(Guid InterniDokumentID)
        {
            return context.InterniDokumenti.FirstOrDefault(e => e.InterniDokumentID == InterniDokumentID);
        }
        /// <summary>
        /// Cuva interne dokumente
        /// </summary>
        /// <returns> Vraca sacuvane promene </returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
       
}