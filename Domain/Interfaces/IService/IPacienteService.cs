using API_Teste_Ténico.DTOs.PacienteDTO;
using Domain.DTOs.PacienteDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IPacienteService
    {
        Task<IList<PacienteDTO>> ObterTodosPacientes();
        Task CriarPaciente(Paciente paciente);
        Task<Paciente?> ObterPacientePorId(int id);
        Task<bool> AtualizarPaciente(PacienteUpdateDTO pacienteDTO);
    }
}
