using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Data
{
    public interface IJavnoNadmetanjeRepository
    {
        List<JavnoNadmetanjeEntity> GetJavnoNadmetanje();

        JavnoNadmetanjeEntity GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID);

        JavnoNadmetanjeEntity CreateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanje);

        void UpdateJavnoNadmetanje(JavnoNadmetanjeEntity javnoNadmetanje);

        void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID);

        bool SaveChanges();
    }
}
