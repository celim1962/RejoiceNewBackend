namespace RejoiceNewBackend.Model
{
    public class TripDetailSchedule
    {
        public int Id { get; set; }
        public int TripDetailId { get; set; }
        public int DayNumber { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? ActivityDescription { get; set; }
        public string ActivityName { get; set; } = string.Empty;
        public string ActivityLocation { get; set; } = string.Empty;
        public List<string>? ActivityImgUrl { get; set; }
    }
}
