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
    public class DashboardController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DashboardController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("id/dashboard")] // just to follow the frontend api convention
        public async Task<ActionResult<DashboardView>> GetSummary()
        {
            var view = await _context.Dashboard_View
                .FirstOrDefaultAsync();

             return Ok(new ReturnSingleDataDto<DashboardView>
            {
                Data = view
            });
        }
    }
}