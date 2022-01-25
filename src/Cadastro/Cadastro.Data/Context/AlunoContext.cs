using System.Data.Entity;
using Cadastro.Data.EntityConfig;
using Cadastro.Data.Pocos;

namespace Cadastro.Data.Context
{
    public class AlunoContext : DbContext
    {
        public AlunoContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<AlunoPoco> Alunos { get; set; }
        public DbSet<EnderecoPoco> Endereco { get; set; }
        public DbSet<AlunoEmailsEnviados> AlunoEmailsEnviados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new AlunoEmailsEnviadosConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}