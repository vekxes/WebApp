using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Apartment : Entity
    {        
        [DisplayName("Номер квартиры")]
        public int NumberOfApartment { get; set; }

        [DisplayName("Ссылка на сайт застройщика")]
        public string? Url { get; set; }

        [DisplayName("Текущая цена")]
        public double Price { get; set; }

        [DisplayName("Количество комнта")]
        public int Rooms { get;set; }

        [DisplayName("История цен")]
        [ForeignKey("ApartmentPriceHistory")]
        public virtual ICollection<ApartmentPriceHistory>? PriceHistory { get; set; }
        

    }
}
