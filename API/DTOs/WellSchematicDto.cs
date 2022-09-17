namespace API.DTOs
{
    public class WellSchematicDto
    {
        public int Id { get; set; }
        public float Top { get; set; }
        public float Bottom { get; set; }
        public float OD { get; set; }
        public float TOC { get; set; }
        public string Type { get; set; }
        public int WellId { get; set; }
    }
}