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
    public class ContaReceitaController : ControllerBase
    {
        private readonly IContaReceitaRepository<ContaReceita> _repository;
        
        public ContaReceitaController(IContaReceitaRepository<ContaReceita> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ContaReceita> GetById(int Id) 
        {
            return await _repository.GetEntityById(Id);
        }

        [HttpGet]
        public async Task<List<ContaReceita>> GetAll()
        {
            return await _repository.List();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContaReceita conta)
        {
            await _repository.Add(conta);

            if (conta.Notifications.Count > 0)
            {
                return BadRequest(new { erro = conta.Notifications });
            }

            return CreatedAtAction(nameof(GetById), new { id = conta.Id }, conta);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] ContaReceita conta) 
        {
            await _repository.Update(conta);

            if(conta.Notifications.Count > 0) 
            {
                return BadRequest(new { error = conta.Notifications });
            }

            return NoContent();
        }
    }
}
