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
            
        }

        public List<DokumentEntity> GetDokument()
        {
            return context.Dokumenti.ToList();
        }

        public DokumentEntity GetDokumentID(Guid DokumentID)
        {
            return null;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateDokument(DokumentEntity Dokument)
        {
            
        }
    }
}
