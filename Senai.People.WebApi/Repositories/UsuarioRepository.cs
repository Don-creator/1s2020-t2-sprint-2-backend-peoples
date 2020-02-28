using Senai.People.WebApi.Domains;
using Senai.People.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";


        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            string querySelect = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuarios WHERE Email = @Email AND Senha = @Senha";


            using (SqlCommand cmd = new SqlCommand(querySelect, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    UsuarioDomain usuario = new UsuarioDomain();

                    while (rdr.Read())
                    {
                        usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);

                        usuario.Email = rdr["Email"].ToString();

                        usuario.Senha = rdr["Senha"].ToString();

                        usuario.Permissao = rdr["Permissao"].ToString();

                    }
                    return usuario;
                }
            }
            return null;
        }
    }
}
