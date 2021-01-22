using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class PagamentoDespesasController : ControllerBase
    {
        private readonly IPagamentoDespesaRepository<PagamentoDespesa> _repository;

        public PagamentoDespesasController(IPagamentoDespesaRepository<PagamentoDespesa> repository)
        {
            _repository = repository;
        }

        // GET: api/PagamentoDespesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoDespesa>>> GetAll()
        {
            return await _repository.List();
        }

        // GET: api/PagamentoDespesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoDespesa>> GetById(int id)
        {
            var pagamentoDespesa = await _repository.GetEntityById(id);

            if (pagamentoDespesa == null)
            {
                return NotFound();
            }

            return pagamentoDespesa;
        }

        // PUT: api/PagamentoDespesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamentoDespesa(int id, PagamentoDespesa pagamentoDespesa)
        {
            if (id != pagamentoDespesa.Id)
            {
                return BadRequest();
            }

            await _repository.Update(pagamentoDespesa);

            if (pagamentoDespesa.Notifications.Count > 0) 
            {
                return BadRequest(new { error = pagamentoDespesa.Notifications });
            }


            return NoContent();
        }

        // POST: api/PagamentoDespesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PagamentoDespesa>> PostPagamentoDespesa(PagamentoDespesa pagamentoDespesa)
        {
            await _repository.Add(pagamentoDespesa);

            if (pagamentoDespesa.Notifications.Count > 0)
            {
                return BadRequest(new { erro = pagamentoDespesa.Notifications });
            }

            return CreatedAtAction(nameof(GetById), new { id = pagamentoDespesa.Id }, pagamentoDespesa);
        }

        // DELETE: api/PagamentoDespesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentoDespesa(int id)
        {
            throw new NotImplementedException();
        }

    }
}
