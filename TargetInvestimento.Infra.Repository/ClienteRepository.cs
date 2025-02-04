﻿using Dapper;
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


        public void UpdateEnderecoClienteById(Endereco endereco)
        {
            var query = "UPDATE ENDERECO SET LOGRADOURO = @LOGRADOURO, BAIRRO = @BAIRRO, UF = @UF, COMPLEMENTO = @COMPLEMENTO, CIDADE = @CIDADE WHERE IDENDERECO = @IDENDERECO";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, endereco);
            }
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
        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            var query = "SELECT * FROM PESSOA P INNER JOIN ENDERECO E ON P.IDPESSOA = E.IDPESSOA";

            using(var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query(query, (Cliente p, Endereco e)
                    =>
                { p.Endereco = e; return p; }, splitOn: "IDENDERECO").ToList();

                //return connection.Query
                //(query, (Candidato c, Usuario u) => { c.Usuario = u; return c; },
                //splitOn: "IdUsuario").ToList();


                return result;
            }


        }


    }
}
