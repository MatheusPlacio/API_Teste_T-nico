using Domain.DTOs.ConvenioDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IConvenioService
    {
        Task<IList<ConvenioDTO>> BuscarConvenios();
        Task<Convenio?> ObterConvenioPorId(int id);
        Task CriarConvenio(ConvenioDTO convenio);
        Task<bool> DeleterConvenio(int id);
    }
}
