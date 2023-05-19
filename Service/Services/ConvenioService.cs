using API_Teste_Ténico.DTOs.ConvenioDTO;
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

        public async Task<bool> AtualizarConvenio(ConvenioUpdateDTO convenio)
        {
            var convenioDb = await _convenioRepository.GetById(convenio.ConvenioId);

            if (convenioDb == null) { return false; }
            
            convenioDb.Update(convenio.Nome, convenio.Descricao);

            await _convenioRepository.Update(convenioDb);
            return true;
        }
    }
}
