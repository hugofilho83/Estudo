using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Helpers;
using Backend.Models;
using Backend.Repository;
using Backend.Repository.Contract;
using Backend.Services;
using Backend.Services.Contract;
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
        private readonly IUsuarioRepository<Usuario> _repository;
        private readonly IUriService _uriService;
        public UsuarioController(IUsuarioRepository<Usuario> repository, IUriService uriService)
        {
            _repository = repository;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _repository.List(filter);

            var totalRecords = await _repository.GetTotalRegister();

            var pagedReponse = PaginationHelper.CreatePagedReponse<Usuario>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedReponse);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int Id)
        {
            var usuario = await _repository.GetEntityById(Id);

            if (usuario == null)
            {
                var response = new Response<Usuario>(null);
                response.Message = "Usuário não localizado.";
                response.Succeeded = false;
                return NotFound(response);
            }

            return Ok(new Response<Usuario>(usuario));
        }

        [AllowAnonymous]
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

                return Ok(new {token = token, Expires = Expires });
            }

            return BadRequest(new { erro = "Usuário localizado." });
        }
    }
}
