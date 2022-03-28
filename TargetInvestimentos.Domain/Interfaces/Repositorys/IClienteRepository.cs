
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Domain.Entities;
using TargetInvestimento.Domain.Interfaces.Repositorys;

namespace TargetInvestimento.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface especifica para operações de repositorio voltadas para Cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetEnderecoClientByCpf(string cpf);
    }
}
