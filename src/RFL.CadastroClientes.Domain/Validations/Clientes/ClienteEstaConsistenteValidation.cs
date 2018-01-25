using DomainValidation.Validation;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDevePossuirCPFValidoSpecification();
            var EmailCliente = new ClienteDevePossuirEmailValidoSpecification();
            var MaioridadeCliente = new ClienteDevePossuirMaioridadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente com CPF inválido"));
            base.Add("EmailCliente", new Rule<Cliente>(EmailCliente, "Cliente com CPF inválido"));
            base.Add("MaioridadeCliente", new Rule<Cliente>(MaioridadeCliente, "Cliente com CPF inválido"));
        }
    }
}
