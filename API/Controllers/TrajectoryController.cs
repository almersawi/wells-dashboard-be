using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class TrajectoryController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrajectoryController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("wellId/{wellId}")]
        public async Task<ActionResult<List<TrajectoryDto>>> GetWellTrajectory(int wellId)
        {
            var data = await _context.Trajectory
                .Where(x => x.WellId == wellId)
                .ProjectTo<TrajectoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

             return Ok(new ReturnDataListDto<TrajectoryDto>
            {
                Data = data
            });
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddWellTrajectory(AddTrajectoryDto addDto)
        {
            // remove all available data
            var oldData = await _context.Trajectory.Where(x => x.WellId == addDto.WellId).ToListAsync();
            _context.Trajectory.RemoveRange(oldData);

            // calculate trajectory
            addDto.Data.Sort((a, z) => z.Md.CompareTo(z.Md));
            var calculatedTrajectory = TrajectoryCalculations.Calculate(addDto.Data);
            var dataToStore = new List<Trajectory>{};
            _mapper.Map(calculatedTrajectory, dataToStore);

            // add to database
            await _context.Trajectory.AddRangeAsync(dataToStore);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}