using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class VendaItensRepository : RepositoryBase<VendaItens>, IVendaItensRepository
    {
        public VendaItensRepository()
        {
        }
    }
}