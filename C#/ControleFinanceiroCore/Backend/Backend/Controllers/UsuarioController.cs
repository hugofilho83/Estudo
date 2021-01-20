using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repository;
using Backend.Repository.Contract;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository<Usuario> _repository;
        public UsuarioController(IUsuarioRepository<Usuario> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAll()
        {
            return await _repository.List();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int Id)
        {
            var usuario = await _repository.GetEntityById(Id);

            if (usuario == null)
                NotFound(new { message = "Usuario não localizado...." });

            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Usuario model)
        {
            await _repository.Add(model);

            if (model.Notifications.Count > 0)
            {
                return BadRequest(new { erro = model.Notifications });
            }

            return CreatedAtAction(nameof(GetUsuarioById), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Usuario model)
        {
            await _repository.Update(model);

            if (model.Notifications.Count > 0)
            {
                return BadRequest(new { erro = model.Notifications });
            }

            return NoContent();
        }


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Authenticate([FromBody] Usuario model)
        {

            var User = ((UsuarioRepository)_repository).Logar(model.Email, model.Senha);

            if (User != null)
            {
                var Expires = DateTime.UtcNow.AddHours(1);

                var token = TokenService.GenerateToken(User, Expires);
                User.Senha = "";

                return Ok(new { user = User, token = token, Expires = Expires });
            }

            return BadRequest(new { erro = "Usuário localizado." });
        }
    }
}
