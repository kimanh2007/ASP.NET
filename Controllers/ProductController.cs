using DangNuKimAnh_2122110482_b2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DangNuKimAnh_2122110482_b2.Data;

namespace DangNuKimAnh_2122110482_b2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _context.Products
                                         .Include(p => p.Category)
                                         .ToListAsync();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.Category)
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.CategoryId = updatedProduct.CategoryId;
            product.UserUpdate = updatedProduct.UserUpdate;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // DELETE: api/product/5?userDelete=admin
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string userDelete)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            // Xoá mềm
            product.DeletedAt = DateTime.UtcNow;
            product.UserDelete = userDelete;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xoá mềm sản phẩm." });
        }
    }
}
