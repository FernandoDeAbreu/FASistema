using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFormaPagamentoServices _fornecedorServices;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FornecedorController(IFormaPagamentoServices formaPagamentoServices, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _fornecedorServices = formaPagamentoServices;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpPost("/api/FornecedorCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Add(formaPagamento);
            return formaPagamento;
        }

        [HttpGet("/api/FornecedorGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _formaPagamentoRepository.GetEntityById(id);
        }

        [HttpGet("/api/FornecedorGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _formaPagamentoRepository.List();
        }

        [HttpPut("/api/FornecedorAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Update(formaPagamento);

            return Task.FromResult(formaPagamento);
        }
    }
}