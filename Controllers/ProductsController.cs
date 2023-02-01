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
  public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
  {
    IEnumerable<Product> products = await _context.Products.ToListAsync();
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    Product? product = await _context.Products.FindAsync(id);
    if (product == null) return NotFound();

    return Ok(product);
  }
}