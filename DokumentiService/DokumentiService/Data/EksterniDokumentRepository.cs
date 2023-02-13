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

        }

        public List<EksterniDokumentEntity> GetEksterniDokument()
        {
            return context.EksterniDokumenti.ToList();
        }

        public EksterniDokumentEntity GetEksterniDokumentID(Guid EksterniDokumentID)
        {
            return null;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEksterniDokument(EksterniDokumentEntity EksterniDokument)
        {

        }
    }
}
