using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaItensController : ControllerBase
    {
        private readonly IFormaPagamentoServices _vendaItensServices;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public VendaItensController(IFormaPagamentoServices formaPagamentoServices, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _vendaItensServices = formaPagamentoServices;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpPost("/api/VendaItensCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Add(formaPagamento);
            return formaPagamento;
        }

        [HttpGet("/api/VendaItensGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _formaPagamentoRepository.GetEntityById(id);
        }

        [HttpGet("/api/VendaItensGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _formaPagamentoRepository.List();
        }

        [HttpPut("/api/VendaItensAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Update(formaPagamento);

            return Task.FromResult(formaPagamento);
        }
    }
}