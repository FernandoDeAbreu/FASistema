using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class MesaRepository : RepositoryBase<Mesa>, IMesaRepository
    {
        public MesaRepository()
        {
        }
    }
}