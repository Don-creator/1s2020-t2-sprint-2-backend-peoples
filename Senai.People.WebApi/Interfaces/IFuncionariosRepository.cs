using Senai.Peoples.WebApi.Controllers;
using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
        interface IFuncionariosRepository
        {
            List<FuncionariosDomain> Listar();

            FuncionariosDomain BuscarPorId(int id);
        }
        
    
}
