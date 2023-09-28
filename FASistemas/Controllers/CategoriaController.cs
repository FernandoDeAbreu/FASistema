using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FASistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServices _categoriaServices;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaServices categoriaServices, ICategoriaRepository categoriaRepository)
        {
            _categoriaServices = categoriaServices;
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost("/api/CadastrarCategoria")]
        [Produces("application/json")]
        public async Task<object> Cadastrar(Categoria categoria)
        {
            await _categoriaRepository.Add(categoria);
            return categoria;
        }

        [HttpGet("/api/CategoriaGetById")]
        [Produces("application/json")]
        public async Task<object> GetById(int id)
        {
            return await _categoriaRepository.GetEntityById(id);
        }

        [HttpGet("/api/CategoriaGetAll")]
        [Produces("application/json")]
        public async Task<object> GetAll()
        {
            return await _categoriaRepository.List();
        }

        [HttpPut("/api/CategoriaAtualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(Categoria categoria)
        {
            await _categoriaRepository.Update(categoria);

            return Task.FromResult(categoria);
        }
    }
}