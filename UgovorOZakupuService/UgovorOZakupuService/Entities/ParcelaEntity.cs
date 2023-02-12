using System.ComponentModel.DataAnnotations;

namespace UgovorOZakupuService.Entities
{
    public class ParcelaEntity
    {
        public ParcelaEntity()
        {
        }
        [Key]
        public Guid ParcelaID { get; set; }

        public string? UkupnaPovrsina { get; set; }



       

      
   }
}
