using DokumentiService.Entities;
using AutoMapper;

namespace DokumentiService.Data
{
    public class InterniDokumentRepository : IInterniDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;

        public InterniDokumentRepository(DokumentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public InterniDokumentEntity CreateInterniDokument(InterniDokumentEntity InterniDokument)
        {
            return null;
        }

        public void DeleteInterniDokument(Guid InterniDokumentID)
        {
            InterniDokumentEntity? interniDokument = GetInterniDokumentID(InterniDokumentID);
            if (interniDokument != null)
                context.Remove(interniDokument);

        }

        public List<InterniDokumentEntity> GetInterniDokument()
        {
            return context.InterniDokumenti.ToList();
        }

        public InterniDokumentEntity GetInterniDokumentID(Guid InterniDokumentID)
        {
            return context.InterniDokumenti.FirstOrDefault(e => e.InterniDokumentID == InterniDokumentID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateInterniDokument(DokumentEntity InterniDokument)
        {
            
        }
    }
       
}