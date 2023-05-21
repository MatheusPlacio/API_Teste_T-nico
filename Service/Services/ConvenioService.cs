using AutoMapper;
using Domain.DTOs.ConvenioDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Service.Services
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;
        public ConvenioService(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public async Task<IList<ConvenioDTO>> BuscarConvenios()
        {
            var convenios = await _convenioRepository.Get();

            var conveniosDTO = convenios.Select(c => new ConvenioDTO
            {
                ConvenioId = c.ConvenioId,
                Nome = c.Nome,
                Descricao = c.Descricao
            }).ToList();

            return conveniosDTO;
        }

        public async Task CriarConvenio(ConvenioDTO convenio)
        {
            var convenioEntity = new Convenio
            {
                Nome = convenio.Nome,
                Descricao = convenio.Descricao
            };

            await _convenioRepository.Add(convenioEntity);
        }

    }
}
