using Backend.Models;
using Backend.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class ParcelaReceitasController : ControllerBase
    {
        private readonly IParcelaReceitaRepository<ParcelaReceita> _repository;

        public ParcelaReceitasController(IParcelaReceitaRepository<ParcelaReceita> repository)
        {
            _repository = repository;
        }

        // GET: api/ParcelaReceitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelaReceita>>> GetParcelaReceitas()
        {
            return await _repository.List();
        }

        // GET: api/ParcelaReceitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelaReceita>> GetParcelaReceita(int id)
        {
            var parcelaReceita = await _repository.GetEntityById(id);

            if (parcelaReceita == null)
            {
                return NotFound();
            }

            return  Ok(parcelaReceita);
        }

        // PUT: api/ParcelaReceitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcelaReceita(int id, ParcelaReceita parcelaReceita)
        {
            if (id != parcelaReceita.Id)
            {
                return BadRequest(new { error = "parcela não encontrada"});
            }

            await _repository.Update(parcelaReceita);

            if (parcelaReceita.Notifications.Count > 0) 
            {
                return BadRequest(new { error = parcelaReceita.Notifications });
            }

            return NoContent();
        }

        // POST: api/ParcelaReceitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParcelaReceita>> PostParcelaReceita(ParcelaReceita parcelaReceita)
        {
            await _repository.Add(parcelaReceita);

            if(parcelaReceita.Notifications.Count > 0) 
            {
                return BadRequest(new { error = parcelaReceita.Notifications });
            }

            return CreatedAtAction("GetParcelaReceita", new { id = parcelaReceita.Id }, parcelaReceita);
        }

        // DELETE: api/ParcelaReceitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcelaReceita(int id)
        {
            throw new NotImplementedException();
        }
    }
}
