using Microsoft.AspNetCore.Mvc;
using Senai.People.WebApi.Domains;
using Senai.People.WebApi.Interfaces;
using Senai.People.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Controllers
{
    [Produces("aplication/json")]
    [Route("api/[controller")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);


            if(usuarioBuscado = null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaim.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaim.Senha, usuarioBuscado.Senha),
            }

        }
    }
}
