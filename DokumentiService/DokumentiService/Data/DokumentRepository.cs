using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

namespace DokumentiService.Data
{
    /// <summary>
	/// Repozitorijum za entitet Dokument.
	/// </summary>
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
        public DokumentRepository (DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
		/// Dodaje novi dokument, koje kasnije vraća kao DTO objekat.
		/// </summary>
		/// <param name="dokumentCreateDTO">DTO za kreiranje dokumenta.</param>
		/// <returns>Vraća DTO kreiranog dokumenta.</returns>
        public DokumentDTO CreateDokument(DokumentCreateDTO dokumentCreateDTO)
        {
            DokumentEntity Dokument = mapper.Map<DokumentEntity>(dokumentCreateDTO);
            Dokument.DokumentID = Guid.NewGuid();
            context.Add(Dokument);
            return mapper.Map<DokumentDTO>(Dokument);
        }

        /// <summary>
        /// Brise zadati dokument
        /// </summary>
        /// <param name="DokumentID"></param>
        public void DeleteDokument(Guid DokumentID)
        {
            DokumentEntity? Dokument = GetDokumentID(DokumentID);
            if (Dokument != null)
                context.Remove(Dokument);
        }

        /// <summary>
		/// Vraća listu dokumenata iz konteksta.
		/// </summary>
		/// <returns>Vraća listu dokumenata.</returns>
        public List<DokumentEntity> GetDokument()
        {
            return context.Dokumenti.ToList();
        }

        /// <summary>
		/// Vraća jedan dokument iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="DokumentID">ID dokumenta.</param>
		/// <returns>Vraća specificiran dokument.</returns>
        public DokumentEntity GetDokumentID(Guid DokumentID)
        {
            return context.Dokumenti.FirstOrDefault(e => e.DokumentID == DokumentID);
        }

        /// <summary>
        /// Cuva promene
        /// </summary>
        /// <returns>Sacuvane promene</returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        
    }
}
