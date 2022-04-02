using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Application.Models;
using TargetInvestimento.Application.Models.Cliente;
using TargetInvestimento.Application.Models.Endereco;
using TargetInvestimento.Application.Models.IBGE;

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
        void UpdateEnderecoClienteById(EnderecoUpdateModel model);

        IList<UFModel> GetUFs();
        IList<MicrorregiaoModel> GetCidadesByUF(int idUF);
    }
}
