using RFL.CadastroClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Domain.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente obj);
        Cliente Atualizar(Cliente obj);
        void Remover(Guid id);
        Cliente BuscaPorId(Guid id);
        Cliente BuscarPorCpf(string cpf);
        Cliente BuscarPorEmail(string email);
        IEnumerable<Cliente> BuscarTodos();
    }
}
