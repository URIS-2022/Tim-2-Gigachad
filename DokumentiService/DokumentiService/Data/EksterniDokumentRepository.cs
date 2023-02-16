using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

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

        public EksterniDokumentDTO CreateEksterniDokument(EksterniDokumentCreateDTO eksterniDokumentCreateDTO)
        {
            EksterniDokumentEntity eksdok = mapper.Map<EksterniDokumentEntity>(eksterniDokumentCreateDTO);
            eksdok.EksterniDokumentID = Guid.NewGuid();
            context.Add(eksdok);
            return mapper.Map<EksterniDokumentDTO>(eksdok);
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

       
    }
}
