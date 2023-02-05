using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste___Webapi.Models;

namespace Teste___Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ShopContext _context;

    public ProductsController(ShopContext context)
    {
    _context = context;

    _context.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] QueryParameters queryParameters)
    {
        IQueryable<Product> products = _context.Products;

        products = products
            .Skip(queryParameters.Size * (queryParameters.Page - 1))
            .Take(queryParameters.Size);


        return Ok(await products.ToArrayAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        Product? product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        if (!ModelState.IsValid) return BadRequest();

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            "GetProduct",
            new { id = product.Id },
            product
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutProduct(int id, [FromBody] Product product)
    {
        if (id != product.Id) return BadRequest();

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(p => p.Id == id)) return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        Product? product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost, Route("Delete")]
    public async Task<ActionResult<IEnumerable<Product>>> DeleteProducts([FromQuery] int[] ids)
    {

        var products = new List<Product>();
        foreach (var id in ids)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            products.Add(product);
        }

        _context.Products.RemoveRange(products);

        await _context.SaveChangesAsync();

        return Ok(products);
    }
}