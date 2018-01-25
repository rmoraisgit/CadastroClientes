using DomainValidation.Interfaces.Specification;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}
