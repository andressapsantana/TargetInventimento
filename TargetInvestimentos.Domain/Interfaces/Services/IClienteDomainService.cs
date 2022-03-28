using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Domain.Entities;

namespace TargetInvestimento.Domain.Services
{
    public interface IClienteDomainService : IBaseDomainService <Cliente>
    {
        Cliente GetEnderecoClientByCpf(string cpf);
    }
}
