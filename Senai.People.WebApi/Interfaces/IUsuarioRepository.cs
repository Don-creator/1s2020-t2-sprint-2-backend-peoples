using Senai.People.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Interfaces
{
        /// <sumary>
        /// Interfac responsavel pelo repositório UsuarioRepository
        /// </sumary>
        interface IUsuarioRepository
        {
            /// <summary>
            /// Valida o Usuario
            /// </summary>
            /// <param name="email"></param>
            /// <param name="senha"></param>
            /// <returns>Retorna um usuario validado</returns>

            UsuarioDomain BuscarPorEmailSenha(string email, string senha);

        }
}
