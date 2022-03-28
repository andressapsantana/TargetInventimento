using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.Endereço
{
    class EnderecoCreateModel
    {
        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(120, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu logradouro.")]
        public string Logradouro { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(80, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu bairro.")]
        public string Bairro { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(8, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu CEP.")]
        public string CEP { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(30, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua cidade.")]
        public string Cidade { get; set; }

        [MinLength(2, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(2, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o UF de sua cidade.")]
        public  string UF { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o complemento.")]
        public string Complemento { get; set; }

        public int IdPessoa { get; set; }

    }
}
