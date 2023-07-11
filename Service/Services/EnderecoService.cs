using Domain.DTOs.EnderecoDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using Newtonsoft.Json;

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
                localidade = endereco.localidade,
                UF = endereco.UF
            };

            if (enderecoDb == null)
            {
                return false;
            }

            await _enderecoRepository.Update(enderecoDb);

            return true;
        }

        public async Task AdicionarEndereco(EnderecoCepDTO cep)
        {
            var viaCepUrl = $"https://viacep.com.br/ws/{cep.Cep}/json/";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(viaCepUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var viaCepResult = JsonConvert.DeserializeObject<EnderecoDTO>(content);

                if (!string.IsNullOrEmpty(viaCepResult.Logradouro))
                {
                    var endereco = new Endereco
                    {
                        EnderecoId = viaCepResult.EnderecoId,
                        Logradouro = viaCepResult.Logradouro,
                        Complemento = viaCepResult.Complemento,
                        Numero = cep.Numero,
                        Cep = viaCepResult.Cep,
                        Bairro = viaCepResult.Bairro,
                        localidade = viaCepResult.localidade,
                        UF = viaCepResult.UF,
                        FuncionarioId = cep.FuncionarioId
                    };

                    // Salva o endereço no banco de dados
                    await _enderecoRepository.Add(endereco);
                }
                else
                {
                    throw new Exception("Não foi possível obter os dados de endereço do CEP informado.");
                }
            }
            else
            {
                throw new Exception("Erro ao consultar o serviço de CEP.");
            }
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

        public async Task<IList<Endereco>> GetTodosEnderecos()
        {
           var result = await _enderecoRepository.GetTodosEnderecos();
           return result;
        }
    }
}
