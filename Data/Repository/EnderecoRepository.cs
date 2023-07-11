using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        private readonly MyContext _context;
        public EnderecoRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Endereco>> GetTodosEnderecos()
        {
            var resultado = await _context.Enderecos.ToListAsync();
            return resultado;
        }
    }
}
