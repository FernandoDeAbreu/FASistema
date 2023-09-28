using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository()
        {
        }
    }
}