using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProductsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _context.Products
                .OrderBy(o => o.Id)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> Get(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(t => t.Id == id);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}

