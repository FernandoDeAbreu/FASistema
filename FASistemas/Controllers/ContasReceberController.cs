using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {
        private readonly IContasReceberServices _contasReceberServices;
        private readonly IContaReceberRepository _contasReceberRepository;

        public ContasReceberController(IContasReceberServices contasReceberServices, IContaReceberRepository contasReceberRepository)
        {
            _contasReceberServices = contasReceberServices;
            _contasReceberRepository = contasReceberRepository;
        }

        [HttpPost("/api/ContasReceberCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(ContasReceber contasReceber)
        {
            await _contasReceberRepository.Add(contasReceber);
            return contasReceber;
        }

        [HttpGet("/api/ContasReceberGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _contasReceberRepository.GetEntityById(id);
        }

        [HttpGet("/api/ContasReceberGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _contasReceberRepository.List();
        }

        [HttpPut("/api/ContasReceberAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(ContasReceber contasReceber)
        {
            await _contasReceberRepository.Update(contasReceber);

            return Task.FromResult(contasReceber);
        }
    }
}