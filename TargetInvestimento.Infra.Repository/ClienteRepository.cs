using Dapper;
using TargetInvestimento.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Domain.Entities;

namespace TargetInvestimento.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string connectionString;

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Cliente obj)
        {
            var query = "INSERT INTO PESSOA (NOMECOMPLETO, DATANASCIMENTO, CPF, RENDAMENSAL) " +
                "VALUES(@NOMECOMPLETO, @DATANASCIMENTO, @CPF, @RENDAMENSAL) " +
                "SELECT SCOPE_IDENTITY()";


            using (var connection = new SqlConnection(connectionString))
            {
                obj.IdPessoa = connection.QuerySingleOrDefault<int>(query, obj);
                var queryEndereco = "";

                if (obj.IdPessoa != 0)
                {
                    queryEndereco = "INSERT INTO ENDERECO (LOGRADOURO, BAIRRO, CEP, CIDADE, UF, COMPLEMENTO, IDPESSOA) " +
                        "VALUES (@LOGRADOURO, @BAIRRO, @CEP, @CIDADE, @UF, @COMPLEMENTO, @IDPESSOA)";
                }

                connection.Execute(queryEndereco, new
                {
                    obj.Endereco.Logradouro,
                    obj.Endereco.Bairro,
                    obj.Endereco.CEP,
                    obj.Endereco.Cidade,
                    obj.Endereco.UF,
                    obj.Endereco.Complemento,
                    obj.IdPessoa
                });
            }
        }

        public void Update(Cliente obj)
        {

        }

        public void Delete(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            var query = @"SELECT P.IDPESSOA, 
                        P.CPF,
                        P.NOMECOMPLETO,
                        P.DATANASCIMENTO,
                        P.RENDAMENSAL,
                        E.IDENDERECO,
                        E.BAIRRO,
                        E.CEP,
                        E.CIDADE,
                        E.COMPLEMENTO,
                        E.LOGRADOURO,
                        E.UF
                        FROM PESSOA P INNER JOIN ENDERECO E
                        ON P.IDPESSOA = E.IDPESSOA
                        WHERE P.IDPESSOA = @IDPESSOA";

            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query(query, (Cliente p, Endereco e) => { p.Endereco = e; return p; }, new { IdPessoa = id }, splitOn: "IDENDERECO").SingleOrDefault();

                return result;
            }


        }

        public Cliente GetEnderecoClientByCpf(string cpf)
        {
            var query = @"SELECT P.IDPESSOA, 
                        P.CPF,
                        P.NOMECOMPLETO,
                        E.IDENDERECO,
                        E.BAIRRO,
                        E.CEP,
                        E.CIDADE,
                        E.COMPLEMENTO,
                        E.LOGRADOURO,
                        E.UF
                        FROM PESSOA P INNER JOIN ENDERECO E
                        ON P.IDPESSOA = E.IDPESSOA
                        WHERE P.CPF = @CPF";

            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query(query, (Cliente p, Endereco e)
                    =>
                { p.Endereco = e; return p; }, new { cpf }, splitOn: "IdEndereco").FirstOrDefault();

                return result;
            }
        }
    }
}
