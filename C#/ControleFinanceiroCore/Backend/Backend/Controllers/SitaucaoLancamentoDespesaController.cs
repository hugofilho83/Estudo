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
    public class SitaucaoLancamentoDespesaController : ControllerBase
    {
        private readonly ISituacaoLancamentoDespesaRepository<SituacaoLancamentoDespesa> _repository;

        public SitaucaoLancamentoDespesaController(ISituacaoLancamentoDespesaRepository<SituacaoLancamentoDespesa> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<SituacaoLancamentoDespesa>> GetAll()
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
        public async Task<IActionResult> Update(int id, SituacaoLancamentoDespesa situacaoLancamentoDespesa)
        {
            if (id != situacaoLancamentoDespesa.Id)
            {
                return BadRequest();
            }

            await _repository.Update(situacaoLancamentoDespesa);

            if (situacaoLancamentoDespesa.Notifications.Count > 0) 
            {
                return BadRequest(new { error = situacaoLancamentoDespesa.Notifications});
            }
            

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SituacaoLancamentoDespesa situacaoLancamentoDespesa)
        {
            await _repository.Add(situacaoLancamentoDespesa);

            return CreatedAtAction("GetById", new { id = situacaoLancamentoDespesa.Id }, situacaoLancamentoDespesa);
        }
    }
}
