using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{   
    public class ProductsController(StoreContext context) : BaseApiController
    {

        [HttpGet] // http://localhost:5001/api/products
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        [HttpGet("{id}")] // http://localhost:5001/api/products/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();                
            
            return product;
        }   
    }
}
