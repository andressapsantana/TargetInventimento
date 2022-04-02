using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Application.Interfaces;
using TargetInvestimento.Application.Models;
using TargetInvestimento.Application.Models.Cliente;
using TargetInvestimento.Application.Models.Endereco;
using TargetInvestimento.Application.Models.IBGE;
using TargetInvestimento.Domain.Entities;
using TargetInvestimento.Domain.Services;

namespace TargetInvestimento.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteDomainService _clientedomainservice;

        public ClienteApplicationService
            (IClienteDomainService clientedomainservice)
        {
            _clientedomainservice = clientedomainservice;
        }
        public void Create(ClienteCreateModel model)
        {
            var cliente = new Cliente();
            cliente.Endereco = new Endereco();

            var cpfExiste = _clientedomainservice.GetEnderecoClientByCpf(model.CPF);

            if (cpfExiste != null)
            {
                return;
            }

            cliente.NomeCompleto = model.NomeCompleto;
            cliente.DataNascimento = model.DataNascimento;
            cliente.CPF = model.CPF;
            cliente.RendaMensal = model.RendaMensal;
            cliente.Endereco.Bairro = model.Bairro;
            cliente.Endereco.CEP = model.CEP;
            cliente.Endereco.Cidade = model.Cidade;
            cliente.Endereco.Complemento = model.Complemento;
            cliente.Endereco.Logradouro = model.Logradouro;
            cliente.Endereco.UF = model.UF;
            _clientedomainservice.Create(cliente);
        }

        public void Update (ClienteUpdateModel model)
        {
            var pessoa = _clientedomainservice.GetById(model.IdPessoa);
            pessoa.NomeCompleto = model.NomeCompleto;
            pessoa.DataNascimento = model.DataNascimento;
            pessoa.CPF = model.CPF;
            _clientedomainservice.Update(pessoa);
        }
        public void Delete (int IdPessoa)
        {
            var pessoa = _clientedomainservice.GetById(IdPessoa);
            _clientedomainservice.Delete(pessoa);
        }
        public List<ClienteGetModel> GetAll()
        {
            var pessoa = new List<ClienteGetModel>();
            foreach (var item in _clientedomainservice.GetAll())
            {
                var model = new ClienteGetModel();
                model.IdPessoa = item.IdPessoa;
                model.NomeCompleto = item.NomeCompleto;
                model.CPF = item.CPF;
                pessoa.Add(model);
            }
            return pessoa;
        }
        public ClienteGetModel GetEnderecoClientByCpf(string cpf)
        {
            var pessoa = _clientedomainservice.GetEnderecoClientByCpf(cpf);

            var model = new ClienteGetModel();
            model.IdPessoa = pessoa.IdPessoa;
            model.NomeCompleto = pessoa.NomeCompleto;
            model.CPF = pessoa.CPF;
            model.Bairro = pessoa.Endereco.Bairro;
            model.CEP = pessoa.Endereco.CEP;
            model.Cidade = pessoa.Endereco.Cidade;
            model.Complemento = pessoa.Endereco.Complemento;
            model.Logradouro = pessoa.Endereco.Logradouro;
            model.UF = pessoa.Endereco.UF;

            return model;

        }

        public ClienteGetModel GetById(int id)
        {
            var pessoa = _clientedomainservice.GetById(id);

            var model = new ClienteGetModel();
            model.IdPessoa = pessoa.IdPessoa;
            model.NomeCompleto = pessoa.NomeCompleto;
            model.CPF = pessoa.CPF;
            model.Bairro = pessoa.Endereco.Bairro;
            model.CEP = pessoa.Endereco.CEP;
            model.Cidade = pessoa.Endereco.Cidade;
            model.Complemento = pessoa.Endereco.Complemento;
            model.Logradouro = pessoa.Endereco.Logradouro;
            model.UF = pessoa.Endereco.UF;

            return model;
        }

        public void UpdateEnderecoClienteById(EnderecoUpdateModel model)
        {
            var endereco = new Endereco();

            var cliente = _clientedomainservice.GetById(model.IdPessoa);

            endereco.IdEndereco = cliente.Endereco.IdEndereco;
            endereco.Logradouro = model.Logradouro;
            endereco.UF = model.UF;
            endereco.Complemento = model.Complemento;
            endereco.Cidade = model.Cidade;
            endereco.CEP = model.CEP;
            endereco.Bairro = model.Bairro;

            _clientedomainservice.UpdateEnderecoClienteById(endereco);
        }

        public IList<UFModel> GetUFs()
        {
            var httpClient = new HttpClient();

            var url = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            var result = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var UFs = JsonConvert.DeserializeObject<List<UFModel>>(resultContent);

            return UFs;
        }

        public IList<MicrorregiaoModel> GetCidadesByUF(int idUF)
        {
            var httpClient = new HttpClient();

            var url = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + idUF + "/microrregioes");
            var result = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var cidades = JsonConvert.DeserializeObject<List<MicrorregiaoModel>>(resultContent);

            return cidades;
        }
    }
}
