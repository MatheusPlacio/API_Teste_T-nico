using AutoMapper;
using Domain.DTOs.EnderecoDTO;
using Domain.DTOs.FuncionarioDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace API_Teste_Ténico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosEnderecos()
        {
            var funcionario = await _funcionarioService.ObterTodosFuncionarios();
            return Ok(funcionario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoPorId(int id)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEndereco(FuncionarioDTO funcionario)
        {
            await _funcionarioService.CriarFuncionario(funcionario);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarFuncionario(Funcionario funcionario)
        {
            var result = await _funcionarioService.AtualizarFuncionario(funcionario);
            if (!result)
            {
                return BadRequest("Funcionário não encontrado");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            var result = await _funcionarioService.DeletarFuncionario(id);
            if (!result)
            {
                return BadRequest("Funcionário não encontrado");
            }
            return Ok("Funcionário excluído com sucesso");
        }
    }
}

