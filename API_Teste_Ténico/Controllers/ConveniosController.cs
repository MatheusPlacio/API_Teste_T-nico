using AutoMapper;
using Domain.DTOs.ConvenioDTO;
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

        [HttpPost]
        public async Task<IActionResult> CriarConvenio(ConvenioDTO convenio)
        {
            await _convenioService.CriarConvenio(convenio);
            return Ok(convenio);
        }

    }
}

