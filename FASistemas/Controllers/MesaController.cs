using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IFormaPagamentoServices _mesaServices;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public MesaController(IFormaPagamentoServices formaPagamentoServices, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _mesaServices = formaPagamentoServices;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        [HttpPost("/api/MesaCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Add(formaPagamento);
            return formaPagamento;
        }

        [HttpGet("/api/MesaGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _formaPagamentoRepository.GetEntityById(id);
        }

        [HttpGet("/api/MesaGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _formaPagamentoRepository.List();
        }

        [HttpPut("/api/MesaAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.Update(formaPagamento);

            return Task.FromResult(formaPagamento);
        }
    }
}