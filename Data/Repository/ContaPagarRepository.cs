using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class ContaPagarRepository : RepositoryBase<ContaPagar>, IContaPagarRepository
    {
        public ContaPagarRepository()
        {
        }
    }
}