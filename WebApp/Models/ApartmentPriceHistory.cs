namespace WebApp.Models
{
    public class ApartmentPriceHistory : Entity
    {        
        public int ApartmentId { get; set; }
        public DateTime PriceChangeDate { get; set; }

        public double PriceAtDate { get; set; }

    }
}
