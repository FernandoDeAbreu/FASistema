using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteServices clienteServices, IClienteRepository clienteRepository)
        {
            _clienteServices = clienteServices;
            _clienteRepository = clienteRepository;
        }

        [HttpPost("/api/ClienteCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);
            return cliente;
        }

        [HttpGet("/api/ClienteGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _clienteRepository.GetEntityById(id);
        }

        [HttpGet("/api/ClienteGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _clienteRepository.List();
        }

        [HttpPut("/api/ClienteAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);

            return Task.FromResult(cliente);
        }
    }
}