using UplataService.Entities;

namespace UplataService.Data
{
    public class UplataRepository : IUplataRepository
    {
        public static List<UplataEntity> Uplate { get; set; } = new List<UplataEntity>();

        public UplataRepository()
        {
            FillData();
        }

        private static void FillData()
        {
            Uplate.AddRange(new List<UplataEntity>
            {
                new UplataEntity
                {
                    UplataID = Guid.Parse("Dodaj guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodaj guid"),
                    KupacID = Guid.Parse("Dodaj guid"),
                    BrojRacuna = "005-417672-67",
                    PozivNaBroj = "73609",
                    Iznos = 45000,
                    Uplatilac = "Pera Peric",
                    SvrhaUplate = "Uplata na racun",
                    //DatumUplate = "6/1/2008 7:47:00 AM"
                    //Katastrofa je DateTime za rad
                    KursnaLista = "???????"
                },
                new UplataEntity
                {
                    UplataID = Guid.Parse("Dodaj guid"),
                    JavnoNadmetanjeID = Guid.Parse("Dodaj guid"),
                    KupacID = Guid.Parse("Dodaj guid"),
                    BrojRacuna = "214-826330-03",
                    PozivNaBroj = "18096",
                    Iznos = 1550,
                    Uplatilac = "Sima Simic",
                    SvrhaUplate = "Racun za Telenor",
                    //DatumUplate = "6/1/2008 7:47:00 AM"
                    //Katastrofa je DateTime za rad
                    KursnaLista = "???????"
                }
            }); ; ;
        }

        public List<UplataEntity> GetUplataEntities()
        {
            throw new NotImplementedException();
        }

        public UplataEntity GetUplataByID(Guid uplataID)
        {
            throw new NotImplementedException();
        }

        public UplataEntity CreateUplata(UplataEntity uplata)
        {
            throw new NotImplementedException();
        }

        public void UpdateUplata(UplataEntity uplata)
        {
            throw new NotImplementedException();
        }

        public void DeleteUplata(Guid uplataID)
        {
            throw new NotImplementedException();
        }
    }
}
