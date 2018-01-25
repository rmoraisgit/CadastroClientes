using DomainValidation.Interfaces.Specification;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _IClienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClienteRepository IClienteRepository)
        {
            _IClienteRepository = IClienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _IClienteRepository.BuscarPorEmail(cliente.Email) == null;
        }
    }
}
