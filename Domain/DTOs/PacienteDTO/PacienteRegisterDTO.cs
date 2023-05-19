using API_Teste_Ténico.DTOs.ConvenioDTO;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Teste_Ténico.DTOs.PacienteDTO
{
    public class PacienteRegisterDTO
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }


        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter 11 digitos", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string RG { get; set; }
        public string UF_RG { get; set; }
        public string? Email { get; set; }
        public string Celular { get; set; }
        public string? TelefoneFixo { get; set; }
        public string CarteirinhaDoConvenio { get; set; }
        public string ValidadeDaCarteirinha { get; set; }
        public int ConvenioId { get; set; }
    }
}
