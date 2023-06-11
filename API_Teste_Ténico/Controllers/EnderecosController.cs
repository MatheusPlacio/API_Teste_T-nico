using API_Teste_Ténico.DTOs.PacienteDTO;
using AutoMapper;
using Domain.DTOs.EnderecoDTO;
using Domain.DTOs.PacienteDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace API_Teste_Ténico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoService enderecoService, IMapper mapper)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosEnderecos()
        {
            var enderecos = await _enderecoService.ObterTodosEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoPorId(int id)
        {
            var enderecos = await _enderecoService.ObterEnderecoPorId(id);
            if (enderecos == null)
            {
                return NotFound();
            }
            return Ok(enderecos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEndereco(EnderecoDTO endereco)
        {
             await _enderecoService.AdicionarEndereco(endereco);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarEndereco(EnderecoDTO endereco)
        {
            var result = await _enderecoService.AtualizarEndereco(endereco);
            if (!result)
            {
                return BadRequest("Endereço não encontrado");
            }
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            var result = await _enderecoService.DeletarEndereco(id);
            if (!result)
            {
                return BadRequest("Endereço não encontrado");
            }
            return Ok("Endereço excluído com sucesso");
        }
    }
}

