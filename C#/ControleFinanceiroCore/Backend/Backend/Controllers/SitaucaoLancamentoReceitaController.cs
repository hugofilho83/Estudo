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
    public class SitaucaoLancamentoReceitaController : ControllerBase
    {
        private readonly ISituacaoLancamentoReceitaRepository<SituacaoLancamentoReceita> _repository;

        public SitaucaoLancamentoReceitaController(ISituacaoLancamentoReceitaRepository<SituacaoLancamentoReceita> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<SituacaoLancamentoReceita>> GetAll()
        {
            return await _repository.List();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var situacaoLancamentoDespesa = await _repository.GetEntityById(id);

            if (situacaoLancamentoDespesa == null)
            {
                return NoContent();
            }

            return Ok(situacaoLancamentoDespesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SituacaoLancamentoReceita situacaoLancamentoReceita)
        {
            if (id != situacaoLancamentoReceita.Id)
            {
                return BadRequest();
            }

            await _repository.Update(situacaoLancamentoReceita);

            if (situacaoLancamentoReceita.Notifications.Count > 0) 
            {
                return BadRequest(new { error = situacaoLancamentoReceita.Notifications});
            }
            

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SituacaoLancamentoReceita sitaucaoLancamentoReceita)
        {
            await _repository.Add(sitaucaoLancamentoReceita);

            return CreatedAtAction("GetById", new { id = sitaucaoLancamentoReceita.Id }, sitaucaoLancamentoReceita);
        }
    }
}
