using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
        public static List<ZalbaEntity> Zalbe { get; set; } = new List<ZalbaEntity>();

        public ZalbaRepository() {
            FillData();
        }

        private void FillData()
        {
            Zalbe.AddRange(new List<ZalbaEntity>
            {
                new ZalbaEntity
                {
                    ZalbaID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
                    KupacID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
                    TipZalbe = "",
                    DatumPodnosenja = DateTime.Parse("2022-12-12"), 
                    Razlog = "",
                    Obrazlozenje = "",
                    StatusZalbe = "",
                    RadnjaZalbe = ""
                },
                new ZalbaEntity
                {
                    ZalbaID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
                    KupacID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
                    TipZalbe = "",
                    DatumPodnosenja = DateTime.Parse("2022-11-11"),
                    Razlog = "",
                    Obrazlozenje = "",
                    StatusZalbe = "",
                    RadnjaZalbe = ""
                }
            });
        }

        public ZalbaEntity CreateZalba(ZalbaEntity zalba)
        {
            throw new NotImplementedException();
        }

        public void DeleteZalba(Guid zalbaID)
        {
            throw new NotImplementedException();
        }

        public ZalbaEntity GetZalbaByID(Guid zalbaID)
        {
            throw new NotImplementedException();
        }

        public List<ZalbaEntity> GetZalbe()
        {
            throw new NotImplementedException();
        }

        public void UpdateZalba(ZalbaEntity zalba)
        {
            throw new NotImplementedException();
        }
    }
}
