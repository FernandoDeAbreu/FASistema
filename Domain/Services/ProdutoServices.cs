using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _repository;

        public ProdutoServices(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Cadastrar(Produto produto)
        {
            await _repository.Add(produto);
        }
    }
}