using JavnoNadmetanjeService.Entities;

namespace LicitacijaService.Data
{
    public interface ILicitacijaRepository
    {
        List<LicitacijaEntity> GetLicitacija();

        LicitacijaEntity GetLicitacijaByID(Guid licitacijaID);

        LicitacijaEntity CreateLicitacija(LicitacijaEntity licitacija);

        void UpdateLicitacija(LicitacijaEntity licitacija);

        void DeleteLicitacija(Guid licitacijaID);

        bool SaveChanges();
    }
}
