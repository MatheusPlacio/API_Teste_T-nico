using Data.Repository;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using Service.Services;

namespace API_Teste_Ténico.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Paciente>, Repository<Paciente>>();
            services.AddScoped<IRepository<Convenio>, ConvenioRepository>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();

            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IConvenioService, ConvenioService>();
        }
    }
}
