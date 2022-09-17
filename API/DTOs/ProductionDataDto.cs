using System;

namespace API.DTOs
{
    public class ProductionDataDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public double Rate { get; set; }
        public double WellheadPressure { get; set; }
        public int WellId { get; set; }
    }
}