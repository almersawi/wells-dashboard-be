using System.Collections.Generic;

namespace API.DTOs
{
    public class AddTrajectoryDto
    {
        public int WellId { get; set; }
        public List<TrajectoryDto> Data { get; set; }
    }
}