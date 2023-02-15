using DokumentiService.Entities;
using AutoMapper;

namespace DokumentiService.Data
{
    public class EksterniDokumentRepository : IEksterniDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;

        public EksterniDokumentRepository(DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public EksterniDokumentEntity CreateEksterniDokument(EksterniDokumentEntity EksterniDokument)
        {
            return null;
        }

        public void DeleteEksterniDokument(Guid EksterniDokumentID)
        {
            EksterniDokumentEntity? eksterniDokument = GetEksterniDokumentID(EksterniDokumentID);
            if (eksterniDokument != null)
                context.Remove(eksterniDokument);
        }

        public List<EksterniDokumentEntity> GetEksterniDokument()
        {
            return context.EksterniDokumenti.ToList();
        }

        public EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID)
        {
            return context.EksterniDokumenti.FirstOrDefault(e => e.EksterniDokumentID == EksterniDokumentID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateEksterniDokument(EksterniDokumentEntity EksterniDokument)
        {

        }
    }
}
