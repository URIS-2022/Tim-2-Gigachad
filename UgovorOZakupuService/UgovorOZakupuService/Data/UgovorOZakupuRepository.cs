using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public class UgovorOZakupuRepository : IUgovorOZakupuRepository
    {
        public static List<UgovorOZakupuEntity> Ugovori { get; set; } = new List<UgovorOZakupuEntity>();

        public UgovorOZakupuRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Ugovori.AddRange(new List<UgovorOZakupuEntity>
            {
                new UgovorOZakupuEntity
                {
                    UgovorOZakupuID = Guid.Parse("Dodajte Guid"),
                    KupacID = Guid.Parse("Dodajte Guid"),
                    OvlascenoLiceID = Guid.Parse("Dodajte Guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodajte Guid"),
                    DokumentID = Guid.Parse("Dodajte Guid"),
                    DatumUgovora = new DateOnly(2007, 01, 05),
                    TrajanjeUgovora = 8,
                    TipGarancije = 5
                },

                new UgovorOZakupuEntity
                {
                    UgovorOZakupuID = Guid.Parse("Dodajte Guid"),
                    KupacID = Guid.Parse("Dodajte Guid"),
                    OvlascenoLiceID = Guid.Parse("Dodajte Guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodajte Guid"),
                    DokumentID = Guid.Parse("Dodajte Guid"),
                    DatumUgovora = new DateOnly(2005, 07, 16),
                    TrajanjeUgovora = 4,
                    TipGarancije = 2
                }
            }); ; ;


        }

        public List<UgovorOZakupuEntity> GetUgovorOZakupu()
        {
            throw new NotImplementedException();
        }

        public UgovorOZakupuEntity GetUgovorOZakupuID(Guid UgovorOZakupuID)
        {
            throw new NotImplementedException();
        }

        public UgovorOZakupuEntity CreateUgovorOZakupu(UgovorOZakupuEntity UgovorOZakupu)
        {
            throw new NotImplementedException();
        }

        public void DeleteUgovorOZakupu(Guid UgovorOZakupuID)
        {
            throw new NotImplementedException();
        }

        public void UpdateUgovorOZakupu(UgovorOZakupuEntity UgovorOZakupu)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

  
}
