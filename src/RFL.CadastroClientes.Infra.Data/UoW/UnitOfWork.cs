using RFL.CadastroClientes.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.CadastroClientes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadastroClientesContext _Context;
        private bool _disposable;

        public UnitOfWork(CadastroClientesContext Context)
        {
            _Context = Context;
            _disposable = false;
        }

        public void Commit()
        {
            _Context.SaveChanges();
        }

        public virtual void Dispose(bool disposed)
        {
            if (!_disposable)
            {
                if (disposed)
                {
                    _Context.Dispose();
                }
            }
            _disposable = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
