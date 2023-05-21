using Domain.DTOs.ConvenioDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IConvenioService
    {
        Task<IList<ConvenioDTO>> BuscarConvenios();
        Task CriarConvenio(ConvenioDTO convenio);
    }
}
