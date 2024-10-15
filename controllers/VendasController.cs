using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Model.Vendas;
using SimpleCrudApp.Data;

[Route ("api/[controller]")]
[ApiController]
public class VendaspedidosController : ControllerBase{
    private readonly ApplicationDbContext _context;
    public VendaspedidosController(ApplicationDbContext context){
        _context = context;
    }
    //GET: api/Vendaspedidos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venda>>> GetVendas(){
        return await _context.Vendas.ToListAsync();
    }
    //GET: api/Vendaspedidos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Venda>> GetVenda(int id){
        var venda = await _context.Vendas.FindAsync(id);
        if(venda == null){
            return NotFound();
        }
        return venda;
    }
    //POST: api/Vendaspedidos
    [HttpPost]
    public async Task<ActionResult<Venda>> PostVenda(Venda venda){
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
    }
    //PUT: api/Vendaspedidos/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Venda>> PutVenda(int id, Venda venda){
        if(id!= venda.Id){
            return BadRequest();
        }
        _context.Entry(venda).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return venda;
    }
    //DELETE: api/Vendaspedidos/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Venda>> DeleteVenda(int id){
        var venda = await _context.Vendas.FindAsync(id);
        if(venda == null){
            return NotFound();
        }
        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync();
        return venda;
    }
    [HttpGet("filter")] // ainda não funcional.
    public async Task<ActionResult<IEnumerable<Venda>>> GetVendasPorPeriodo([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        // Verifica se as datas foram fornecidas corretamente
        if (startDate == default || endDate == default)
        {
            return BadRequest("As datas de início e fim devem ser válidas.");
        }

        // Filtra as vendas no intervalo de datas fornecido
        var vendas = await _context.Vendas
            .Where(v => v.DataDaVenda >= startDate && v.DataDaVenda <= endDate)
            .ToListAsync();

        // Retorna a lista de vendas filtradas
        return Ok(vendas);
    }
}