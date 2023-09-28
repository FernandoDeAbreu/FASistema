using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository()
        {
        }
    }
}