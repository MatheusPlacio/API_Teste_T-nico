using Domain.Models;

namespace Domain.Interfaces.IRepository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<IList<Funcionario>> GetFuncionariosEndereco();
    }
}
