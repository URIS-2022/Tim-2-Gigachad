using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

namespace DokumentiService.Data
{
    /// <summary>
    /// Repozitorijum za eksterni dokument Entity
    /// </summary>
    public class EksterniDokumentRepository : IEksterniDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Inicira Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>

        public EksterniDokumentRepository(DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreira novi eksterni Dokument
        /// </summary>
        /// <param name="eksterniDokumentCreateDTO"></param>
        /// <returns>Vraća DTO kreiranog dokumenta</returns>
        public EksterniDokumentDTO CreateEksterniDokument(EksterniDokumentCreateDTO eksterniDokumentCreateDTO)
        {
            EksterniDokumentEntity eksdok = mapper.Map<EksterniDokumentEntity>(eksterniDokumentCreateDTO);
            eksdok.EksterniDokumentID = Guid.NewGuid();
            context.Add(eksdok);
            return mapper.Map<EksterniDokumentDTO>(eksdok);
        }

        /// <summary>
        /// Brise zadati eksterni dokument
        /// </summary>
        /// <param name="EksterniDokumentID"></param>
        public void DeleteEksterniDokument(Guid EksterniDokumentID)
        {
            EksterniDokumentEntity? eksterniDokument = GetEksterniDokumentID(EksterniDokumentID);
            if (eksterniDokument != null)
                context.Remove(eksterniDokument);
        }


        /// <summary>
		/// Vraća listu eksternih dokumenata iz konteksta.
		/// </summary>
		/// <returns>Vraća listu eksternih dokumenata.</returns>
        public List<EksterniDokumentEntity> GetEksterniDokument()
        {
            return context.EksterniDokumenti.ToList();
        }


        /// <summary>
		/// Vraća jedan eskterni dokument iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="EksterniDokumentID">ID dokumenta.</param>
		/// <returns>Vraća specificiran eksterni dokument.</returns>
        public EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID)
        {
            return context.EksterniDokumenti.FirstOrDefault(e => e.EksterniDokumentID == EksterniDokumentID);
        }

        /// <summary>
        /// Cuva eksterne dokumente
        /// </summary>
        /// <returns> Vraca potvrdu o sacuvanim promenama </returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

       
    }
}
