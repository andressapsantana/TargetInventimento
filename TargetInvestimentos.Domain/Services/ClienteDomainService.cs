using TargetInvestimento.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Domain.Entities;

namespace TargetInvestimento.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Cliente GetEnderecoClientByCpf(string cpf)
        {
            return clienteRepository.GetEnderecoClientByCpf(cpf);
        }

        public void UpdateEnderecoClienteById(Endereco endereco)
        {
            #region Atualizar o endereço do cliente

            clienteRepository.UpdateEnderecoClienteById(endereco);

            #endregion
        }

    }
}
