﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.IBGE
{
    public class MunicipiosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public MicrorregiaoModel Microrregiao { get; set; }
    }
}
