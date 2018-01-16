using RFL.CadastroClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using RFL.CadastroClientes.Infra.Data.EntityConfig;

namespace RFL.CadastroClientes.Infra.Data.Contexts
{
    public class CadastroClientesContext : DbContext
    {
        public CadastroClientesContext() : base("DefaultConnection") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Where(p => p.Name == p.ReflectedType + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(p => p.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(p => p.Entity.GetType().GetProperty("Ativo") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativo").CurrentValue = true;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Ativo").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
