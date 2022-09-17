using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Views;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class WellSummaryController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WellSummaryController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("id/{wellId}")]
        public async Task<ActionResult<WellSummaryView>> GetWellSummary(int wellId)
        {
            var wellView = await _context.Well_Summary_view
                .Where(x => x.WellId == wellId)
                .SingleOrDefaultAsync();

             return Ok(new ReturnSingleDataDto<WellSummaryView>
            {
                Data = wellView
            });
        }
    }
}