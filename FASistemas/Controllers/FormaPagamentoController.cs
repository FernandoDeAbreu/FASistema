using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoServices _formaPagamentoServices;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoController(IFormaPagamentoServices formaPagamentoServices, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _formaPagamentoServices = formaPagamentoServices;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpPost("/api/FormaPagamentoCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Add(formaPagamento);
            return formaPagamento;
        }

        [HttpGet("/api/FormaPagamentoGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _formaPagamentoRepository.GetEntityById(id);
        }

        [HttpGet("/api/FormaPagamentoGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _formaPagamentoRepository.List();
        }

        [HttpPut("/api/FormaPagamentoAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Update(formaPagamento);

            return Task.FromResult(formaPagamento);
        }
    }
}