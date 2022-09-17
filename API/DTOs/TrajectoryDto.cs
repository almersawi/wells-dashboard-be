namespace API.DTOs
{
    public class TrajectoryDto
    {
        public int Id { get; set; }
        public double Md { get; set; }
        public double Tvd { get; set; }
        public double Inc { get; set; }
        public double Azi { get; set; }
        public double North { get; set; }
        public double East { get; set; }
        public int WellId { get; set; }
    }
}