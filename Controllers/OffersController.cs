using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Controllers
{
    [Route("api/offers")]
    public class OffersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OffersController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> Get()
        {
            var offers = await _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Supplier)
                .OrderBy(o => o.Id)
                .ToListAsync();

            return Ok(offers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> Get(int id)
        {
            var offer = await _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (offer == null) return NotFound();

            return Ok(offer);
        }
    }
}

