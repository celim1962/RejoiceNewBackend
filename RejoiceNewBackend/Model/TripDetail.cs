namespace RejoiceNewBackend.Model
{
    public class TripDetail
    {
        public int Id { get; set; }
        public int TripCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? HomePageImgUrl { get; set; }
        public List<string>? DetailImgUrl { get; set; }
        public int MaxOrderPeople { get; set; }
    }
}
