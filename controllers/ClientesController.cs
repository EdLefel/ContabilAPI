// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Data;
using SimpleCrudApp.client.models;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClient()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, Client cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClientExists(id))
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
    public async Task<IActionResult> DeleteClient(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClientExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}
