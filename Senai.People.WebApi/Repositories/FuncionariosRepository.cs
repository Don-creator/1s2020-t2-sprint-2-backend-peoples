using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public FuncionariosDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionarios, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios WHERE IdFuncionarios = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        FuncionariosDomain funcionarioBuscado = new FuncionariosDomain
                        {
                            // Atribui à propriedade Idfilme o valor da coluna "Idfilme" da tabela do banco
                            IdFuncionarios = Convert.ToInt32(rdr["IdFuncionarios"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            NomeFuncionario = rdr["NomeFuncionario"].ToString()
                            ,
                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString()
                        };

                        // Retorna o filme com os dados obtidos
                        return funcionarioBuscado;
                    }
                    // Caso o resultado da query não possua registros, retorna null
                    return null;

                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionarios, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FuncionariosDomain Funcionarios = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFuncionarios = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeFuncionario = rdr["NomeFuncionario"].ToString()
                            ,
                            SobrenomeFuncionario = rdr["SobrenomeFuncionario"].ToString()
                        };

                        // Adiciona o genero criado à tabela filme
                        funcionarios.Add(Funcionarios);
                    }
                }
            }
            return funcionarios;
        }
        public void Cadastrar(FuncionariosDomain funcionario)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                // string queryInsert = "INSERT INTO filme(Nome) VALUES ('" + filme.Nome + "')";
                // Não usar dessa forma pois pode causar o efeito Joana D'arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE filme--'"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela generos do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                // Declara a query que será executada passando o valor como parâmetro, evitando assim os problemas acima
                string queryInsert = "INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario) VALUES(@NomeFuncionario, @SobrenomeFuncionario)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleta um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionarios = @IdFuncionarios";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@IdFuncionarios", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarIdUrl(int id, FuncionariosDomain funcionario)
          {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario WHERE IdFuncionarios = @IdFuncionarios";


                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IdFuncionarios", id);
                    cmd.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                    cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdCorpo(FuncionariosDomain funcionarios)
            {
                // Declara a conexão passando a string de conexão
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    // Declara a query que será executada
                    string queryUpdate = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario =  @SobrenomeFuncionario WHERE IdFuncionario = @IdFuncionario";

                    // Declara o SqlCommand passando o comando a ser executado e a conexão
                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        // Passa os valores dos parâmetros
                        cmd.Parameters.AddWithValue("@IdFuncionarios", funcionarios.IdFuncionarios);
                        cmd.Parameters.AddWithValue("@NomeFuncionario", funcionarios.NomeFuncionario);
                        cmd.Parameters.AddWithValue("@SobrenomeFuncionario", funcionarios.SobrenomeFuncionario);


                        // Abre a conexão com o banco de dados
                        con.Open();

                        // Executa o comando
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
