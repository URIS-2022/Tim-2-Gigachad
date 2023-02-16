using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    public interface IZalbaRepository
    {
        List<ZalbaEntity> GetZalbe();

        ZalbaEntity? GetZalbaByID(Guid zalbaID);

        ZalbaDTO CreateZalba(ZalbaCreateDTO zalba);

        void DeleteZalba(Guid zalbaID);

        bool SaveChanges();
    }
}
