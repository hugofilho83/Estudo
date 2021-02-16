using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Backend.Repository.Contract;

namespace Backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class RecebimentoReceitasController : ControllerBase
    {
        private readonly IRecebimentoReceitaRepository<RecebimentoReceita> _repository;

        public RecebimentoReceitasController(IRecebimentoReceitaRepository<RecebimentoReceita> repository)
        {
            _repository = repository;
        }

        // GET: api/RecebimentoReceitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecebimentoReceita>>> GetRecebimentoReceitas()
        {
            return await _repository.List();
        }

        // GET: api/RecebimentoReceitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecebimentoReceita>> GetRecebimentoReceita(int id)
        {
            var recebimentoReceita = await _repository.GetEntityById(id);

            if (recebimentoReceita == null)
            {
                return NotFound(new { error = "Recebimento não localizado" });
            }

            return recebimentoReceita;
        }

        // PUT: api/RecebimentoReceitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecebimentoReceita(int id, RecebimentoReceita recebimentoReceita)
        {
            if (id != recebimentoReceita.Id)
            {
                return BadRequest();
            }

            await _repository.Update(recebimentoReceita);

            if (recebimentoReceita.Notifications.Count > 0)
                return BadRequest(new { error = recebimentoReceita.Notifications });

            return NoContent();
        }

        // POST: api/RecebimentoReceitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecebimentoReceita>> PostRecebimentoReceita(RecebimentoReceita recebimentoReceita)
        {
            await _repository.Add(recebimentoReceita);

            if (recebimentoReceita.Notifications.Count > 0)
                return BadRequest(new { error = recebimentoReceita.Notifications });

            return CreatedAtAction("GetRecebimentoReceita", new { id = recebimentoReceita.Id }, recebimentoReceita);
        }

        // DELETE: api/RecebimentoReceitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecebimentoReceita(int id)
        {
            throw new NotImplementedException();
        }              
    }
}
