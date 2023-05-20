using API_Teste_Ténico.DTOs.ConvenioDTO;
using AutoMapper;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Service.Services
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;
        private readonly IMapper _mapper;
        public ConvenioService(IConvenioRepository convenioRepository, IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _mapper = mapper;
        }

        public async Task<IList<Convenio>> BuscarConvenios()
        {
           return await _convenioRepository.Get();
        }

        public async Task CriarConvenio(Convenio convenio)
        {
            await _convenioRepository.Add(convenio);
        }

        public async Task<Convenio?> ObterConvenioPorId(int id)
        {
            return await _convenioRepository.GetById(id);
        }

        public async Task<bool> AtualizarConvenio(ConvenioUpdateDTO convenioDTO)
        {
            if (convenioDTO == null) { return false; }

            var convenioDb = await _convenioRepository.GetById(convenioDTO.ConvenioId);

            if (convenioDb == null) { return false; }

            _mapper.Map(convenioDTO, convenioDb);

            await _convenioRepository.Update(convenioDb);
            return true;
        }

    }
}
