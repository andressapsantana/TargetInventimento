﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Application.Models.Endereco
{
    public class EnderecoGetModel
    {
        public  int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public  string Bairro { get; set; }
        public  string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int IdPessoa { get; set; }

    }
}
