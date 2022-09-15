using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WellsController : ControllerBase
    {
        private readonly DataContext _context;
        public WellsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Well>>> GetWells()
        {
            return await _context.Wells.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Well>> GetWell(int id)
        {
            return await _context.Wells.FindAsync(id);
        }
    }
}