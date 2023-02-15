using DokumentiService.Entities;
using AutoMapper;

namespace DokumentiService.Data
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;

        public DokumentRepository (DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public DokumentEntity CreateDokument(DokumentEntity Dokument)
        {
            return null;
        }

        public void DeleteDokument(Guid DokumentID)
        {
            DokumentEntity? Dokument = GetDokumentID(DokumentID);
            if (Dokument != null)
                context.Remove(Dokument);
        }

        public List<DokumentEntity> GetDokument()
        {
            return context.Dokumenti.ToList();
        }

        public DokumentEntity GetDokumentID(Guid DokumentID)
        {
            return context.Dokumenti.FirstOrDefault(e => e.DokumentID == DokumentID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateDokument(DokumentEntity Dokument)
        {
            
        }
    }
}
