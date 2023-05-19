using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }

        [StringLength(11, ErrorMessage = "O campo {0} precisa ter 11 digitos", MinimumLength = 11)]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 7)]
        public string RG { get; set; }

        public string UF_RG { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter no mínimo1 11 digitos", MinimumLength = 11)]
        public string Celular { get; set; }

        public string? TelefoneFixo { get; set; }
        public string CarteirinhaDoConvenio { get; set; }
        public string ValidadeDaCarteirinha { get; set; }


        // EF Relacionamento
        public Convenio Convenio { get; set; }
        public int ConvenioId { get; set; }
    }
}
