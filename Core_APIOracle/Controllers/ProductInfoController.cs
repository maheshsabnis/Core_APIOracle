using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_APIOracle.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_APIOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly OraDbContext _context;

        public ProductInfoController(OraDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Products.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductsInfo productsInfo)
        {
            var result = await _context.Products.AddAsync(productsInfo);
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }
    }
}
