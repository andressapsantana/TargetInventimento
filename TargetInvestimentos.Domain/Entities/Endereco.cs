using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Domain.Entities
{
    public class Endereco
    {
        #region Propriedades    

        public virtual int IdPessoa { get; set; }
        public virtual int IdEndereco { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string UF { get; set; }
        public virtual string Complemento { get; set; }

        #endregion



    }
}

