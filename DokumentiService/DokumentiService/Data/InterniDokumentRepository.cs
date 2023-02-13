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
            
        }

        public List<InterniDokumentEntity> GetInterniDokument()
        {
            return context.InterniDokumenti.ToList();
        }

        public InterniDokumentEntity GetInterniDokumentID(Guid InterniDokumentID)
        {
            return null;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateInterniDokument(DokumentEntity InterniDokument)
        {
            
        }
    }
       
}