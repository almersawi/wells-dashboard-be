using System.Collections.Generic;

namespace API.Entities
{
    public class Well
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string StringType { get; set; }
        public ICollection<Schematic> Schematic { get; set; }
        public ICollection<Trajectory> Trajectory { get; set; }
        public ICollection<ProductionData> ProductionData { get; set; }
    }
}