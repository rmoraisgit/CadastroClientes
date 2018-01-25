using RFL.CadastroClientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Interfaces.Repository;
using RFL.CadastroClientes.Domain.Validations.Clientes;

namespace RFL.CadastroClientes.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _IClienteRepository;

        public ClienteService(IClienteRepository IClienteRepository)
        {
            _IClienteRepository = IClienteRepository;
        }

        public Cliente Adicionar(Cliente obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }

            obj.ValidationResult = new ClienteAptoParaCadastroValidation(_IClienteRepository).Validate(obj);

            if (!obj.ValidationResult.IsValid)
            {
                return obj;
            }

            return _IClienteRepository.Adicionar(obj);
        }

        public Cliente Atualizar(Cliente obj)
        {
            return _IClienteRepository.Atualizar(obj);
        }

        public Cliente BuscaPorId(Guid id)
        {
            return _IClienteRepository.BuscaPorId(id);
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            return _IClienteRepository.BuscarPorCpf(cpf);
        }

        public Cliente BuscarPorEmail(string email)
        {
            return _IClienteRepository.BuscarPorEmail(email);
        }

        public IEnumerable<Cliente> BuscarTodos()
        {
            return _IClienteRepository.BuscarTodos();
        }

        public void Remover(Guid id)
        {
            _IClienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _IClienteRepository.Dispose();
        }
    }
}
