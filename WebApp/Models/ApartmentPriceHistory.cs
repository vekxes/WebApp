namespace WebApp.Models
{
    public class ApartmentPriceHistory
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public DateTime PriceChangeDate { get; set; }

    }
}
