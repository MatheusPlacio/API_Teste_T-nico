using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        private readonly MyContext _context;
        public FuncionarioRepository(MyContext context) : base (context)
        {
            _context = context;
        }

        public async Task<IList<Funcionario>> GetFuncionariosEndereco()
        {
            var resultado = await _context.Funcionarios.Include(x => x.Endereco).ToListAsync();
            return resultado;
        }
    }
}
