using AutoMapper;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{

    public class ParcelaRepository : IParcelaRepository
    {
       public static List<ParcelaEntity> Parcele { get; set; } = new List<ParcelaEntity>();

        public ParcelaRepository() 
        {
            FillData();
        }

        private void FillData() 
        {
            Parcele.AddRange(new List<ParcelaEntity>
           {
               new ParcelaEntity
               {
                   ParcelaID = Guid.Parse("Dodaje Guid"),
                   UkupnaPovrsina = "1000 ha"
               },

               new ParcelaEntity
               {
                   ParcelaID = Guid.Parse("Dodaj Guid"),
                   UkupnaPovrsina = "2000 ha"
               }
           }); ; ;
        }
        public ParcelaEntity CreateParcela(ParcelaEntity parcela)
        {
            return null;
        }

        public void DeleteParcela(Guid parcelaID)
        {
            Console.WriteLine("Nek pise nesto");
        }

        public List<ParcelaEntity> GetParcela()
        {
            return context.Parcela.ToList();
        }

        public ParcelaEntity GetParcelabyID(Guid parcelaID)
        {
            return null;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >0;
        }

        public void UpdateParcela(ParcelaEntity parcela)
        {
            Console.WriteLine("Nek pise nesto");
        }
    }

}
