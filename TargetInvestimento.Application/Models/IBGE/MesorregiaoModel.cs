using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.IBGE
{
    public class MesorregiaoModel
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public UFModel Uf { get; set; }
    }
}
