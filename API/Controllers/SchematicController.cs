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
    public class SchematicController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SchematicController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("wellId/{wellId}")]
        public async Task<ActionResult<List<WellSchematicDto>>> GetWellSchematic(int wellId)
        {
            var data = await _context.Schematic
                .Where(x => x.WellId == wellId)
                .ProjectTo<WellSchematicDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

             return Ok(new ReturnDataListDto<WellSchematicDto>
            {
                Data = data
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<WellDto>> AddWellSchematic(WellSchematicDto addDto)
        {
            var schematic = new Schematic
            { };

            _mapper.Map(addDto, schematic);

            _context.Schematic.Add(schematic);
            await _context.SaveChangesAsync();

            var dataToReturn = _mapper.Map<WellSchematicDto>(schematic);

            return Ok(dataToReturn);
        }

        [HttpPut("update")]
        public async Task<ActionResult<WellSchematicDto>> UpdateWellSchematic(WellSchematicDto updateDto)
        {
            var schematic = await _context.Schematic
                .Where(x => x.Id == updateDto.Id)
                .FirstOrDefaultAsync();

            if (schematic == null)
            {
                return BadRequest("No well with this id");
            }

            _mapper.Map(updateDto, schematic);
            _context.Schematic.Update(schematic);

            await _context.SaveChangesAsync();

            var dataToReturn = _mapper.Map<WellSchematicDto>(schematic);

            return Ok(dataToReturn);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteWell(int id)
        {
            var schematic = await _context.Schematic
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (schematic == null)
            {
                return BadRequest("No well with this id");
            }

            _context.Schematic.Remove(schematic);

            await _context.SaveChangesAsync();

            return Ok("Entry Deleted");
        }
    }
}