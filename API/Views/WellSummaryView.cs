using System;

namespace API.Views
{
    public class WellSummaryView
    {
        public int WellId { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
        public string Type { get; set; }
        public string StringType { get; set; }
        
        public float? Lat { get; set; }
        public float? Lon { get; set; }
        public double? MinProdRate { get; set; }
        public double? MaxProdRate { get; set; }
        public double? AvgProdRate { get; set; }
        public double? LastProdRate { get; set; }
        public double? MinWhPressure { get; set; }
        public double? MaxWhPressure { get; set; }
        public double? AvgWhPressure { get; set; }
        public double? LastWhPressure { get; set; }
        public float? MaxSchematicBottom { get; set; }
        public double? LastNorth { get; set; }
        public double? LastEast { get; set; }
        public double? LastTvd { get; set; }
        public DateTime? LastProdDate { get; set; }
        public DateTime? LastWhPressureDate { get; set; }

    }
}