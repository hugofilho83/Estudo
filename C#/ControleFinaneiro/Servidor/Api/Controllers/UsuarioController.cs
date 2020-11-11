using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Context;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{

  [ApiVersion("1.0")]
  [Authorize]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [Produces("application/json")]
  public class UsuarioController : ControllerBase
  {
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<dynamic>> Get([FromServices] ApplicationDbContext context, Guid id)
    {
      var usaurio = await context.Usuarios.FindAsync("C998997F-EEB2-4376-8AA4-78672C4C4D73");

      if (usaurio == null)
        return BadRequest(new { messager = "usuario não localizado." });

      return Ok(usaurio);
    }

    [Route("login")]
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Autheticate([FromServices] ApplicationDbContext context, [FromBody] Usuarios model)
    {
      DateTime Expire = DateTime.UtcNow.AddHours(2);
      var usuario = await context.Usuarios.Where(
          u => u.Login.ToLower() == model.Login.ToLower() && u.Senha == model.Senha
      ).FirstOrDefaultAsync();

      if (usuario == null)
        return BadRequest(new { messager = "Usuário e/ou senha inválido." });

      if (!usuario.Ativo)
        return BadRequest(new { messager = "Usuário bloqueado." });

      var token = ToKenService.GenerateToken(usuario, Expire);

      return Ok(new { usuario = usuario, token, Expire });
    }
  }
}
