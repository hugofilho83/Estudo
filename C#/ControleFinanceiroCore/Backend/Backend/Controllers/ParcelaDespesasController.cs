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
    public class ParcelaDespesasController : ControllerBase
    {
        private readonly IParecelaDepesaRepository<ParcelaDespesa> _repository;

        public ParcelaDespesasController(IParecelaDepesaRepository<ParcelaDespesa> repository)
        {
            _repository = repository;
        }

        // GET: api/ParcelaDespesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelaDespesa>>> GetAll()
        {
            return await _repository.List();
        }

        // GET: api/ParcelaDespesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelaDespesa>> GetParcelaDespesa(int id)
        {
            var parcelaDespesa = await _repository.GetEntityById(id);

            if (parcelaDespesa == null)
            {
                return NotFound();
            }

            return parcelaDespesa;
        }

        // PUT: api/ParcelaDespesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcelaDespesa(int id, ParcelaDespesa parcelaDespesa)
        {
            if (id != parcelaDespesa.Id)
            {
                return BadRequest();
            }

            await _repository.Update(parcelaDespesa);

            if (parcelaDespesa.Notifications.Count > 0)
            {
                return BadRequest(new { error = parcelaDespesa.Notifications });
            }

            return NoContent();
        }

        // POST: api/ParcelaDespesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParcelaDespesa>> PostParcelaDespesa(ParcelaDespesa parcelaDespesa)
        {
            await _repository.Add(parcelaDespesa);

            if (parcelaDespesa.Notifications.Count > 0)
                return BadRequest(new { error = parcelaDespesa.Notifications });

            return CreatedAtAction("GetParcelaDespesa", new { id = parcelaDespesa.Id }, parcelaDespesa);
        }

        // DELETE: api/ParcelaDespesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcelaDespesa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
