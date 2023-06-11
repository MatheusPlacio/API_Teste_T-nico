using Domain.DTOs.EnderecoDTO;
using Domain.DTOs.FuncionarioDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;

namespace Service.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public async Task<bool> AtualizarFuncionario(Funcionario funcionario)
        {

            await _funcionarioRepository.Update(funcionario);

            return true;
        }

        public async Task CriarFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarioDb = new Funcionario
            {
                FuncionarioId = funcionario.FuncionarioId,
                Nome = funcionario.Nome,
                SobreNome = funcionario.SobreNome,
                Idade = funcionario.Idade,
                Endereco = new Endereco
                {
                    EnderecoId = funcionario.Endereco.EnderecoId,
                    Logradouro = funcionario.Endereco.Logradouro,
                    Complemento = funcionario.Endereco.Complemento,
                    Numero = funcionario.Endereco.Numero,
                    Cep = funcionario.Endereco.Cep,
                    Bairro = funcionario.Endereco.Bairro,
                    Cidade = funcionario.Endereco.Cidade,
                    UF = funcionario.Endereco.UF
                }
            };

            await _funcionarioRepository.Add(funcionarioDb);
        }

        public async Task<bool> DeletarFuncionario(int id)
        {
            var result = await _funcionarioRepository.GetById(id);
            if (result == null)
            {
                return false;
            }

            await _funcionarioRepository.Delete(result);
            return true;

        }

        public async Task<Funcionario?> ObterFuncionarioPorId(int id)
        {
            var result = await _funcionarioRepository.GetById(id);
            return result;
        }

        public async Task<IList<Funcionario>> ObterTodosFuncionarios()
        {
           var result = await _funcionarioRepository.GetFuncionariosEndereco();
            return result;
        }
    }
}
