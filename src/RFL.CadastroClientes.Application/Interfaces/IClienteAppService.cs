using RFL.CadastroClientes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj);
        ClienteViewModel Atualizar(ClienteViewModel obj);
        void Remover(Guid id);
        ClienteViewModel BuscaPorId(Guid id);
        ClienteViewModel BuscarPorCpf(string cpf);
        ClienteViewModel BuscarPorEmail(string email);
        IEnumerable<ClienteViewModel> BuscarTodos();
    }
}
