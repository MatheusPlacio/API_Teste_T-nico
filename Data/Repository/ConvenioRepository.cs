using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;

namespace Data.Repository
{
    public class ConvenioRepository : Repository<Convenio>, IConvenioRepository
    {
        public ConvenioRepository(MyContext context) : base(context)
        {
           
        }
        
    }
}
