using Backend.Models;
using Backend.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class LancamentoDespesaController : ControllerBase
    {
        private readonly ILancamentoDespesaRepository<LancamentosDespesa> _repository;

        public LancamentoDespesaController(ILancamentoDespesaRepository<LancamentosDespesa> repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<LancamentosDespesa>> GetAll()
        {
            return await _repository.List();
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LancamentosDespesa LancamentoDespesa)
        {
            if (id != LancamentoDespesa.Id)
            {
                return BadRequest();
            }

            await _repository.Update(LancamentoDespesa);

            if (LancamentoDespesa.Notifications.Count > 0)
            {
                return BadRequest(new { error = LancamentoDespesa.Notifications });
            }


            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LancamentosDespesa lancamento)
        {
            await _repository.Add(lancamento);

            return CreatedAtAction("GetById", new { id = lancamento.Id }, lancamento);
        }
    }
}
