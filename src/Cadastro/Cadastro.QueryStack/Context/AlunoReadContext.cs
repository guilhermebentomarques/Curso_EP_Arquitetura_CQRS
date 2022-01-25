using System.Data.Entity;
using Cadastro.QueryStack.Models;

namespace Cadastro.QueryStack.Context
{
    public class AlunoReadContext : DbContext
    {
        public AlunoReadContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<AlunoEndereco> AlunoEnderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoEndereco>()
                .HasKey(c => c.AlunoId)
                .ToTable("AlunoEndereco");

            base.OnModelCreating(modelBuilder);
        }
    }
}