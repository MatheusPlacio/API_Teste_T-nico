using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.ConvenioDTO
{
    public class ConvenioDTO
    {
        public int ConvenioId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
    }
}
