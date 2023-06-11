using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        private readonly MyContext _context;
        public PacienteRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Paciente>> GetPacientes()
        {
            var resultado = await _context.Pacientes.Include(x => x.Convenio).ToListAsync();
            return resultado;
        }
    }
}
