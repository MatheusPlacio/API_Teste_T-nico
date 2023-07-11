using Domain.Models;

namespace Domain.Interfaces.IRepository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IList<Endereco>> GetTodosEnderecos();
    }
}
