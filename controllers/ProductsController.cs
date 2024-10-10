// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Data;
using SimpleCrudApp.models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> GetProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    // POST: api/Products
    [HttpPost]
    public async Task<ActionResult<Products>> PostProduto(Products produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Products produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Id == id);
    }
}
