using API_Teste_Ténico.DTOs.PacienteDTO;
using AutoMapper;
using Domain.DTOs.PacienteDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste_Ténico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosPacientes()
        {
            var pacientes = await _pacienteService.ObterTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPacientePorId(int id)
        {
            var paciente = await _pacienteService.ObterPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPaciente(PacienteRegisterDTO pacienteDTO)
        {
           await _pacienteService.CriarPaciente(_mapper.Map<Paciente>(pacienteDTO));
            return Ok(pacienteDTO);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPaciente(PacienteUpdateDTO pacienteDTO)
        {
            var result = await _pacienteService.AtualizarPaciente(pacienteDTO);
            if (!result)
            {
                return BadRequest("Paciente não encontrado");
            }
            return Ok(pacienteDTO);
        }
    }
}
