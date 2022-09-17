using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Production_Data")]
    public class ProductionData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public double WellheadPressure { get; set; }
        public Well Well { get; set; }
        public int WellId { get; set; }
    }
}