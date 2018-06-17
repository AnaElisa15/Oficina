using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models.DAL
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MeuContexto>());
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }

    }

}