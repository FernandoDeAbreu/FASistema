using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IProdutoServices
    {
        Task Cadastrar(Produto produto);
    }
}