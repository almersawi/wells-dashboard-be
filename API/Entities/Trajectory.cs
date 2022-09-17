using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Well_Trajectory")]
    public class Trajectory
    {
        public int Id { get; set; }
        public double Md { get; set; }
        public double Tvd { get; set; }
        public double Inc { get; set; }
        public double Azi { get; set; }
        public double North { get; set; }
        public double East { get; set; }
        public Well Well { get; set; }
        public int WellId { get; set; }
    }
}