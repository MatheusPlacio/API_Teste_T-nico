using API_Teste_Ténico.DTOs.ConvenioDTO;
using AutoMapper;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste_Ténico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConveniosController : ControllerBase
    {
        private readonly IConvenioService _convenioService;
        private readonly IMapper _mapper;

        public ConveniosController(IConvenioService convenioService, IMapper mapper)
        {
            _convenioService = convenioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosConvenios()
        {
            var convenios = await _convenioService.BuscarConvenios();
            return Ok(convenios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterConvenioPorId(int id)
        {
            var convenios = await _convenioService.ObterConvenioPorId(id);
            if (convenios == null)
            {
                return NotFound();
            }
            return Ok(convenios);
        }

        [HttpPost]
        public async Task<ActionResult<ConvenioRegisterDTO>> CriarConvenio(ConvenioRegisterDTO convenioDTO)
        {
            await _convenioService.CriarConvenio(_mapper.Map<Convenio>(convenioDTO));
            return Ok(convenioDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ConvenioUpdateDTO>> AtualizarConvenio(ConvenioUpdateDTO convenioDTO)
        {
            var result = await _convenioService.AtualizarConvenio(convenioDTO);
            if (!result)
            {
                return BadRequest("Convênio não encontrado");
            }
            return Ok(convenioDTO);
        }
    }
}

