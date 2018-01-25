using DomainValidation.Validation;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Interfaces.Repository;
using RFL.CadastroClientes.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository _IClienteRepository)
        {
            var UnicoCPFCliente = new ClienteDevePossuirCPFUnicoSpecification(_IClienteRepository);
            var UnicoEmailCliente = new ClienteDevePossuirEmailUnicoSpecification(_IClienteRepository);

            base.Add("UnicoCPFCliente", new Rule<Cliente>(UnicoCPFCliente, "CPF já cadastrado"));
            base.Add("UnicoEmailCliente", new Rule<Cliente>(UnicoEmailCliente, "Email já cadastrado"));
        }
    }
}
