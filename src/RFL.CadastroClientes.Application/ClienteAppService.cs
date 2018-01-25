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
using RFL.CadastroClientes.Infra.Data.UoW;

namespace RFL.CadastroClientes.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _IClienteService;
        private readonly IUnitOfWork _IUnitOfWork;

        public ClienteAppService(IClienteService IClienteService, IUnitOfWork IUnitOfWork)
        {
            _IClienteService = IClienteService;
            _IUnitOfWork = IUnitOfWork;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj);
            var endereco = Mapper.Map<Endereco>(obj);
            cliente.Enderecos.Add(endereco);

            var retornoCliente =_IClienteService.Adicionar(cliente);

            if (retornoCliente.ValidationResult.IsValid)
            {
                _IUnitOfWork.Commit();
            }

            obj = Mapper.Map<ClienteEnderecoViewModel>(retornoCliente);

            return obj;
        }

        public ClienteViewModel Atualizar(ClienteViewModel obj)
        {
            var cliente = Mapper.Map<Cliente>(obj);
            _IClienteService.Atualizar(cliente); 
            
                _IUnitOfWork.Commit();
           

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

            _IUnitOfWork.Commit();
        }

        public void Dispose()
        {
            _IClienteService.Dispose();
        }
    }
}
