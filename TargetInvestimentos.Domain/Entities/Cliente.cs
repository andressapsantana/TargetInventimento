using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Domain.Entities
{
    public class Cliente
    {
        public virtual int IdPessoa { get; set; }
        public virtual string NomeCompleto { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string CPF { get; set; }
        public virtual decimal RendaMensal { get; set; }
        public virtual int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
