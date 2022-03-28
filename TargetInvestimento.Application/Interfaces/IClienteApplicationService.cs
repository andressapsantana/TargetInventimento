using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Application.Models.Cliente;

namespace TargetInvestimento.Application.Interfaces
{
    public interface IClienteApplicationService
    {
        void Create(ClienteCreateModel model);
        void Update(ClienteUpdateModel model);
        void Delete(int IdPessoa);
        List<ClienteGetModel> GetAll();
        ClienteGetModel GetEnderecoClientByCpf(string CPF);
        ClienteGetModel GetById(int id);
    }
}
