using API_Teste_Ténico.DTOs.ConvenioDTO;
using API_Teste_Ténico.DTOs.PacienteDTO;
using AutoMapper;
using Domain.DTOs.PacienteDTO;
using Domain.Models;

namespace API_Teste_Ténico.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Convenio, ConvenioRegisterDTO>().ReverseMap();
            CreateMap<Convenio, ConvenioUpdateDTO>().ReverseMap();
            CreateMap<Paciente, PacienteRegisterDTO>().ReverseMap();
            CreateMap<Paciente, PacienteUpdateDTO>().ReverseMap();
        }   
    }
}
