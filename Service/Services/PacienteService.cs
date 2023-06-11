using AutoMapper;
using Domain.DTOs.PacienteDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IList<PacienteDTO>> ObterTodosPacientes()
        {
            var pacientes = await _pacienteRepository.GetPacientes();
            var pacientesDTO = pacientes.Select(p => new PacienteDTO
            {
                PacienteId = p.PacienteId,
                Nome = p.Nome,
                SobreNome = p.SobreNome,
                DataDeNascimento = p.DataDeNascimento,
                Genero = p.Genero,
                CPF = p.CPF,
                RG = p.RG,
                UF_RG = p.UF_RG,
                Email = p.Email,
                Celular = p.Celular,
                TelefoneFixo = p.TelefoneFixo,
                CarteirinhaDoConvenio = p.CarteirinhaDoConvenio,
                ValidadeDaCarteirinha = p.ValidadeDaCarteirinha,
                NomeConvenio = p.Convenio.Nome 
            }).ToList();

            return pacientesDTO;
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
            var resultado = await _pacienteRepository.GetById(id);

            if (resultado == null)
                throw new Exception("Paciente não encontrado");

            return resultado;
        }

        public async Task<bool> AtualizarPaciente(PacienteUpdateDTO pacienteDTO)
        {
            var existingPaciente = await _pacienteRepository.Buscar(c => (c.CPF == pacienteDTO.CPF || c.RG == pacienteDTO.RG) && c.PacienteId != pacienteDTO.PacienteId);

            if (existingPaciente.Any())
            {
                throw new Exception("Documento já pertence a outro usuário");
            }

            var pacienteDb = await _pacienteRepository.GetById(pacienteDTO.PacienteId);

            if (pacienteDb == null) 
            {
                throw new Exception("Paciente não encontrado");
            }

            _mapper.Map(pacienteDTO, pacienteDb);

            await _pacienteRepository.Update(pacienteDb);
            return true;
        }

        public async Task<bool> DeletarPaciente(int pacienteId)
        {
            var paciente = await _pacienteRepository.GetById(pacienteId);

            if (paciente == null)
            {
                return false; 
            }

            await _pacienteRepository.Delete(paciente);
            return true; 
        }
    }
}
