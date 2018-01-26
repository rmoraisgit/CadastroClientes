using RFL.CadastroClientes.Application.Interfaces;
using RFL.CadastroClientes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RFL.CadastroClientes.REST.ClienteAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _IClienteAppService;

        public ClientesController(IClienteAppService IClienteAppService)
        {
            _IClienteAppService = IClienteAppService;
        }

        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> Get()
        {
            return _IClienteAppService.BuscarTodos();
        }

        // GET: api/Clientes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
