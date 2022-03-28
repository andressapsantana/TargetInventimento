using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.Cliente
{
    public class ClienteUpdateModel
    {
        [Required(ErrorMessage = "Por favor, informe o seu Id.")]
        public  int IdPessoa { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        public  string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua data de nascimento.")]
        public  DateTime DataNascimento { get; set; }

        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu CPF.")]
        public  string CPF { get; set; }
    }
}
