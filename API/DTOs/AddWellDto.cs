namespace API.DTOs
{
    public class AddWellDto
    {
        public string Name { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public float ChokeSize { get; set; }
    }
}