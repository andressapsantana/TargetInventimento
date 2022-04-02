using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Application.Models.Estados;

namespace TargetInvestimento.Application.Models
{
    public class UFModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }        
        public RegiaoModel Regiao { get; set; }
    }
}
