using DokumentiService.Entities;
using AutoMapper;
using DokumentiService.DTO;

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

        public InterniDokumentDTO CreateInterniDokument(InterniDokumentCreateDTO interniDokumentCreateDTO)
        {
            InterniDokumentEntity intdok = mapper.Map<InterniDokumentEntity>(interniDokumentCreateDTO);
            intdok.InterniDokumentID = Guid.NewGuid();
            context.Add(intdok);
            return mapper.Map<InterniDokumentDTO>(intdok);
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

    }
       
}