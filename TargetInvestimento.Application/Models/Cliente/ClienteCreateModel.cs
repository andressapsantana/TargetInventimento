using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.Cliente
{
    public class ClienteCreateModel
    {
        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua data de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [MinLength(5, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua renda mensal.")]
        public decimal RendaMensal { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu logradouro.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu CEP.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu UF.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu complemento.")]
        public string Complemento { get; set; }


    }
}
