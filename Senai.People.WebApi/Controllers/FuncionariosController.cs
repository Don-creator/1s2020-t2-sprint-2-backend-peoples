using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }


        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            return _funcionariosRepository.Listar();
        }
    }
}

