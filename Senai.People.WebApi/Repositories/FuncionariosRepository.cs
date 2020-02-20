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
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=Filmes_tardes; user Id=sa; pwd=sa@132";

        public FuncionariosDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionarios,    NomeFuncionario, SobrenomeFuncionario FROM Funcionarios WHERE IdFuncionarios = @ID";

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
                            IdFuncionarios = Convert.ToInt32(rdr["IdFuncionario"])

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