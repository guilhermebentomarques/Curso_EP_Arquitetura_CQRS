using System.Data.Entity.ModelConfiguration;
using Cadastro.Data.Pocos;

namespace Cadastro.Data.EntityConfig
{
    public class AlunoConfig : EntityTypeConfiguration<AlunoPoco>
    {
        public AlunoConfig()
        {
            HasKey(c => c.AlunoId);

            ToTable("Alunos");
        }
    }
}