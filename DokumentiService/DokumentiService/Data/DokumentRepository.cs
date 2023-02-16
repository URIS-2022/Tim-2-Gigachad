using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

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

        public DokumentDTO CreateDokument(DokumentCreateDTO dokumentCreateDTO)
        {
            DokumentEntity Dokument = mapper.Map<DokumentEntity>(dokumentCreateDTO);
            Dokument.DokumentID = Guid.NewGuid();
            context.Add(Dokument);
            return mapper.Map<DokumentDTO>(Dokument);
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

        
    }
}
