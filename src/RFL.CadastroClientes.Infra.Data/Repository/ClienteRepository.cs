using Dapper;
using RFL.CadastroClientes.Domain.Entities;
using RFL.CadastroClientes.Domain.Interfaces.Repository;
using RFL.CadastroClientes.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CadastroClientesContext Contexto) 
            : base(Contexto)
        {

        }

        public Cliente BuscarPorCpf(string cpf)
        {
            return DbSet.FirstOrDefault(c => c.Cpf == cpf);
        }

        public Cliente BuscarPorEmail(string email)
        {
            return DbSet.FirstOrDefault(c => c.Email == email);
        }

        public override void Remover(Guid id)
        {
            var cliente = BuscaPorId(id);
            cliente.Ativo = false;
            SaveChanges();
        }

        public override IEnumerable<Cliente> BuscarTodos()
        {
            var cn = Db.Database.Connection;
            var strQuery = "select * from clientes";

            return cn.Query<Cliente>(strQuery);
        }
    }
}
