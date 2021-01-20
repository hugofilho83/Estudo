using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ContaDespesasController : ControllerBase
    {
        private readonly IContaDespesaRepository<ContaDespesa> _repository;

        public ContaDespesasController(IContaDespesaRepository<ContaDespesa> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ContaDespesa> GetById(int Id)
        {
            return await _repository.GetEntityById(Id);
        }

        [HttpGet]
        public async Task<List<ContaDespesa>> GetAll()
        {
            return await _repository.List();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContaDespesa conta)
        {
            await _repository.Add(conta);

            if (conta.Notifications.Count > 0)
            {
                return BadRequest(new { erro = conta.Notifications });
            }

            return CreatedAtAction(nameof(GetById), new { id = conta.Id }, conta);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] ContaDespesa conta)
        {
            await _repository.Update(conta);

            if (conta.Notifications.Count > 0)
            {
                return BadRequest(new { error = conta.Notifications });
            }

            return NoContent();
        }
    }
}
