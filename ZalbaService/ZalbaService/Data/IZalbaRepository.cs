using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public interface IZalbaRepository
    {
        List<ZalbaEntity> GetZalbe();

        ZalbaEntity GetZalbaByID(Guid zalbaID);

        ZalbaEntity CreateZalba(ZalbaEntity zalba);

        void UpdateZalba(ZalbaEntity zalba);

        void DeleteZalba(Guid zalbaID);

        bool SaveChanges();
    }
}
