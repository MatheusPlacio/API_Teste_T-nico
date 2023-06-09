﻿using Domain.Models;

namespace Domain.Interfaces.IRepository
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<IList<Paciente>> GetPacientes();
    }
}
