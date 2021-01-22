using Backend.Models;
using Backend.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class LancamentoReceitaController : ControllerBase
    {

        private readonly ILancamentoReceitaRepository<LancamentosReceita> _repository;

        public LancamentoReceitaController(ILancamentoReceitaRepository<LancamentosReceita> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<LancamentosReceita>> GetAll()
        {
            return await _repository.List();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var LancamentoReceita = await _repository.GetEntityById(id);

            if (LancamentoReceita == null)
            {
                return NoContent();
            }

            return Ok(LancamentoReceita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LancamentosReceita LancamentoRecita)
        {
            if (id != LancamentoRecita.Id)
            {
                return BadRequest();
            }

            await _repository.Update(LancamentoRecita);

            if (LancamentoRecita.Notifications.Count > 0)
            {
                return BadRequest(new { error = LancamentoRecita.Notifications });
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LancamentosReceita lancamento)
        {
            await _repository.Add(lancamento);

            if(lancamento.Notifications.Count > 0)
            {
                return BadRequest(new { erro = lancamento.Notifications });
            }

            return CreatedAtAction("GetById", new { id = lancamento.Id }, lancamento);
        }
    }
}
