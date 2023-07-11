using Domain.DTOs.EnderecoDTO;
using Domain.DTOs.PacienteDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IEnderecoService
    {
        Task<IList<Endereco>> GetTodosEnderecos();
        Task AdicionarEndereco(EnderecoCepDTO cep);
        Task<Endereco?> ObterEnderecoPorId(int id);
        Task<bool> AtualizarEndereco(EnderecoDTO endereco);
        Task<bool> DeletarEndereco(int id);
    }
}
