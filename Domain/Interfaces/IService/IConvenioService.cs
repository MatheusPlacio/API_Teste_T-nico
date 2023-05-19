using API_Teste_Ténico.DTOs.ConvenioDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IConvenioService
    {
        Task<IList<Convenio>> BuscarConvenios();
        Task CriarConvenio(Convenio convenio);
        Task<Convenio?> ObterConvenioPorId(int id);
        Task<bool> AtualizarConvenio(ConvenioUpdateDTO convenio);
        Task ExcluirConvenio(int id);
    }
}
