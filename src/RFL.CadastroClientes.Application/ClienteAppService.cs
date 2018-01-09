using RFL.CadastroClientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFL.CadastroClientes.Application.ViewModels;
using RFL.CadastroClientes.Domain.Interfaces;
using AutoMapper;
using RFL.CadastroClientes.Domain.Entities;

namespace RFL.CadastroClientes.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _IClienteService;

        public ClienteAppService(IClienteService IClienteService)
        {
            _IClienteService = IClienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj);
            var endereco = Mapper.Map<Endereco>(obj);
            cliente.Enderecos.Add(endereco);

            _IClienteService.Adicionar(cliente);

            return obj;
        }

        public ClienteViewModel Atualizar(ClienteViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj);
            _IClienteService.Atualizar(cliente);

            return obj;
        }

        public ClienteViewModel BuscaPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_IClienteService.BuscaPorId(id));
        }

        public ClienteViewModel BuscarPorCpf(string cpf)
        {

            return Mapper.Map<ClienteViewModel>(_IClienteService.BuscarPorCpf(cpf));
        }

        public ClienteViewModel BuscarPorEmail(string email)
        {

            return Mapper.Map<ClienteViewModel>(_IClienteService.BuscarPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> BuscarTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_IClienteService.BuscarTodos());
        }

        public void Remover(Guid id)
        {
            _IClienteService.Remover(id);
        }

        public void Dispose()
        {
            _IClienteService.Dispose();
        }
    }
}
