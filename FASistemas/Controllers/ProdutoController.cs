using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoServices produtoServices, IProdutoRepository produtoRepository)
        {
            _produtoServices = produtoServices;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("/api/ProdutoCadastrar")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(Produto produto)
        {
            await _produtoServices.Cadastrar(produto);
            return produto;
        }

        [HttpGet("/api/ProdutoGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _produtoRepository.GetEntityById(id);
        }

        [HttpGet("/api/ProdutoGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _produtoRepository.List();
        }

        [HttpPut("/api/ProdutoAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(Produto produto)
        {
            await _produtoRepository.Update(produto);

            return Task.FromResult(produto);
        }
    }
}