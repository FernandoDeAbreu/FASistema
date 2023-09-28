using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository()
        {
        }
    }
}