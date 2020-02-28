using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        //Define que o formato e que o campo é obrigatorio
        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

         //Define que o campo é obrigatorio, com no minimo 3 caracteres e no maximo 20 caracteres
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no minimo 3 caracteres ")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
