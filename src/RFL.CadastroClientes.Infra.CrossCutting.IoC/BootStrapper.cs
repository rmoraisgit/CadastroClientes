using RFL.CadastroClientes.Application;
using RFL.CadastroClientes.Application.Interfaces;
using RFL.CadastroClientes.Domain.Interfaces;
using RFL.CadastroClientes.Domain.Interfaces.Repository;
using RFL.CadastroClientes.Domain.Services;
using RFL.CadastroClientes.Infra.Data.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //Application
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
        }
    }
}
