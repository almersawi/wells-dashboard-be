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
    public class ProductionDataController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductionDataController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("wellId/{wellId}")]
        public async Task<ActionResult<List<ProductionDataDto>>> GetProductionData(int wellId)
        {
            var data = await _context.ProductionData
                .Where(x => x.WellId == wellId)
                .OrderBy( x => x.Date)
                .ProjectTo<ProductionDataDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

             return Ok(new ReturnDataListDto<ProductionDataDto>
            {
                Data = data
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductionDataDto>> AddProductionData(ProductionDataDto addDto)
        {
            var prodData = new ProductionData
            { };

            _mapper.Map(addDto, prodData);

            _context.ProductionData.Add(prodData);
            await _context.SaveChangesAsync();

            var dataToReturn = _mapper.Map<ProductionDataDto>(prodData);

            return Ok(dataToReturn);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProductionDataDto>> UpdateProductionData(ProductionDataDto updateDto)
        {
            var prodData = await _context.ProductionData
                .Where(x => x.Id == updateDto.Id)
                .FirstOrDefaultAsync();

            var wellId = prodData.WellId;

            if (prodData == null)
            {
                return BadRequest("No data with this id");
            }

            _mapper.Map(updateDto, prodData);
            prodData.WellId = wellId;
            _context.ProductionData.Update(prodData);

            await _context.SaveChangesAsync();

            var dataToReturn = _mapper.Map<ProductionDataDto>(prodData);

            return Ok(dataToReturn);
        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteProductionData(int id)
        {
            var prodData = await _context.ProductionData
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (prodData == null)
            {
                return BadRequest("No data with this id");
            }

            _context.ProductionData.Remove(prodData);

            await _context.SaveChangesAsync();

            return Ok("Data Deleted");
        }
        
    }
}