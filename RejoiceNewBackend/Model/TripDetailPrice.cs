namespace RejoiceNewBackend.Model
{
    public class TripDetailPrice
    {
        public int Id { get; set; }
        public int TripDetailId { get; set; }
        public string? PriceType { get; set; }
        public decimal PriceAmount { get; set; }
    }
}
