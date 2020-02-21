using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.People.WebApi.Repositories;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;

namespace Senai.People.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _funcionariosRepository.Listar();
        }

        public FuncionarioController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _funcionariosRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            // Faz a chamada para o método .Deletar();
            _funcionariosRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Funcionario deletado");
        }

        [HttpPost]
        public IActionResult Post (FuncionariosDomain funcionarios)
        {
            _funcionariosRepository.Cadastrar(funcionarios);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionariosDomain BuscarPorId = _funcionariosRepository.BuscarPorId(id);

            if (BuscarPorId == null)
            {
                return NotFound();
            }
            return Ok(BuscarPorId);
        }
    }
}