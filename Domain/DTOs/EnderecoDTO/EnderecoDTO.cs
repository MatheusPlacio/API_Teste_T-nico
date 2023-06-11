﻿using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.EnderecoDTO
{
    public class EnderecoDTO
    {
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UF { get; set; }
    }
}