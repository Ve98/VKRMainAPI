using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SuppliersController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> Get()
        {
            var suppliers = await _context.Suppliers
                .OrderBy(o => o.Id)
                .ToListAsync();
                
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null) return NotFound();

            return Ok(supplier);
        }
    }
}

