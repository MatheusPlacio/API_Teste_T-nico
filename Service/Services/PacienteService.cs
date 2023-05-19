using API_Teste_Ténico.DTOs.PacienteDTO;
using AutoMapper;
using Domain.DTOs.PacienteDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Service.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IList<Paciente>> ObterTodosPacientes()
        {
            return await _pacienteRepository.Get();
        }

        public async Task CriarPaciente(Paciente paciente)
        {
            if (_pacienteRepository.Buscar(c => c.CPF == paciente.CPF || c.RG == paciente.RG).Result.Any())
            {
                throw new Exception("Documento já cadastrado no sistema");
            }

           await _pacienteRepository.Add(paciente);
        }

        public async Task<Paciente?> ObterPacientePorId(int id)
        {
            return await _pacienteRepository.GetById(id);
        }

        public async Task<bool> AtualizarPaciente(PacienteUpdateDTO pacienteDTO)
        {
            var existingPaciente = await _pacienteRepository.Buscar(c => c.CPF == pacienteDTO.CPF && c.PacienteId != pacienteDTO.PacienteId);

            if (existingPaciente.Any())
            {
                throw new Exception("CPF já pertence a outro usuário");
            }

            var pacienteDb = await _pacienteRepository.GetById(pacienteDTO.PacienteId);

            if (pacienteDb == null) { return false; }

            _mapper.Map(pacienteDTO, pacienteDb);

            await _pacienteRepository.Update(pacienteDb);
            return true;
        }

        public async Task ExcluirPaciente(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);
            if (paciente != null)
            {
               await _pacienteRepository.Delete(paciente);
            }
        }
    }
}
