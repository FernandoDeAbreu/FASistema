using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaPagarController : ControllerBase
    {
        private readonly IContaPagarServices _contaPagarServices;
        private readonly IContaPagarRepository _contaPagarRepository;

        public ContaPagarController(IContaPagarServices contaPagarServices, IContaPagarRepository contaPagarRepository)
        {
            _contaPagarServices = contaPagarServices;
            _contaPagarRepository = contaPagarRepository;
        }

        [HttpPost("/api/ContaPagarCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(ContaPagar contaPagar)
        {
            await _contaPagarRepository.Add(contaPagar);
            return contaPagar;
        }

        [HttpGet("/api/ContaPagarGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _contaPagarRepository.GetEntityById(id);
        }

        [HttpGet("/api/ContaPagarGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _contaPagarRepository.List();
        }

        [HttpPut("/api/ContaPagarAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(ContaPagar contaPagar)
        {
            await _contaPagarRepository.Update(contaPagar);

            return Task.FromResult(contaPagar);
        }
    }
}