using RFL.CadastroClientes.Domain.Interfaces.Repository;
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
            //Domain
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
        }
    }
}
