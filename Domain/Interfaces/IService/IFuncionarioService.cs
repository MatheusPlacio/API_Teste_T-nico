using Domain.DTOs.FuncionarioDTO;
using Domain.DTOs.PacienteDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IFuncionarioService
    {
        Task<IList<Funcionario>> ObterTodosFuncionarios();
        Task CriarFuncionario(FuncionarioDTO funcionario);
        Task<Funcionario?> ObterFuncionarioPorId(int id);
        Task<bool> AtualizarFuncionario(Funcionario funcionario);
        Task<bool> DeletarFuncionario(int id);
    }
}
