using Domain.DTOs.EnderecoDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<bool> AtualizarEndereco(EnderecoDTO endereco)
        {
            var enderecoDb = new Endereco
            {
                EnderecoId = endereco.EnderecoId,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Numero = endereco.Numero,
                Cep = endereco.Cep,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                UF = endereco.UF
            };

            if (enderecoDb == null)
            {
                return false;
            }

            await _enderecoRepository.Update(enderecoDb);

            return true;
        }

        public async Task AdicionarEndereco(EnderecoDTO endereco)
        {
            var enderecoDb = new Endereco
            {
                EnderecoId = endereco.EnderecoId,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Numero = endereco.Numero,
                Cep = endereco.Cep,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                UF = endereco.UF
            };

            await _enderecoRepository.Add(enderecoDb);
        }

        public async Task<bool> DeletarEndereco(int id)
        {
            var resultado = await _enderecoRepository.GetById(id);
            if (resultado == null)
                return false;

            await _enderecoRepository.Delete(resultado);
            return true;
        }

        public async Task<Endereco?> ObterEnderecoPorId(int id)
        {
            var result = await _enderecoRepository.GetById(id);
            return result;
        }

        public async Task<IList<Endereco>> ObterTodosEnderecos()
        {
           var result = await _enderecoRepository.Get();
            return result;
        }
    }
}
