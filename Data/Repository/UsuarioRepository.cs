using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository()
        {
        }
    }
}