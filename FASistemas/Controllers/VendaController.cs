using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IFormaPagamentoServices _vendaServices;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public VendaController(IFormaPagamentoServices formaPagamentoServices, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _vendaServices = formaPagamentoServices;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpPost("/api/VendaCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Add(formaPagamento);
            return formaPagamento;
        }

        [HttpGet("/api/VendaGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _formaPagamentoRepository.GetEntityById(id);
        }

        [HttpGet("/api/VendaGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _formaPagamentoRepository.List();
        }

        [HttpPut("/api/VendaAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Update(formaPagamento);

            return Task.FromResult(formaPagamento);
        }
    }
}