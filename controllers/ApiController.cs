using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Data;

namespace SimpleCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Busca o usuário no banco de dados
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.NomeUser == request.NomeUser && u.PassWord == request.Password);

            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas");
            }

            // Retorna o sucesso no login
            return Ok(new { message = "Login bem-sucedido", userId = usuario.Id, userName = usuario.NomeUser});
        }
    }

    public class LoginRequest
    {
        public string NomeUser { get; set; }
        public string Password { get; set; }
    }

}
