using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class WellController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WellController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ReturnDataListDto<WellDto>>> GetWells()
        {
            var wells = await _context.Wells
                .ProjectTo<WellDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(new ReturnDataListDto<WellDto>
            {
                Data = wells
            });
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<WellDto>> GetWell(int id)
        {
            var well = await _context.Wells
                .Where(x => x.Id == id)
                .ProjectTo<WellDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

             return Ok(new ReturnSingleDataDto<WellDto>
            {
                Data = well
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<WellDto>> AddWell(AddWellDto addDto)
        {
            var well = new Well
            { };

            _mapper.Map(addDto, well);

            _context.Wells.Add(well);
            await _context.SaveChangesAsync();

            var wellToReturn = _mapper.Map<WellDto>(well);

            return Ok(wellToReturn);
        }

        [HttpPut("update")]
        public async Task<ActionResult<WellDto>> UpdateWell(WellDto updateDto)
        {
            var well = await _context.Wells
                .Where(x => x.Id == updateDto.Id)
                .FirstOrDefaultAsync();

            if (well == null)
            {
                return BadRequest("No well with this id");
            }

            _mapper.Map(updateDto, well);
            _context.Wells.Update(well);

            await _context.SaveChangesAsync();

            var wellToReturn = _mapper.Map<WellDto>(well);

            return Ok(wellToReturn);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteWell(int id)
        {
            var well = await _context.Wells
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (well == null)
            {
                return BadRequest("No well with this id");
            }

            _context.Wells.Remove(well);

            await _context.SaveChangesAsync();

            return Ok("Well Deleted");
        }
    }
}