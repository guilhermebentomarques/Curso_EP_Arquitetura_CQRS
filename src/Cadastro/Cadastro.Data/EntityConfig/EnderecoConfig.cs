using System.Data.Entity.ModelConfiguration;
using Cadastro.Data.Pocos;

namespace Cadastro.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<EnderecoPoco>
    {
        public EnderecoConfig()
        {
            HasKey(c => c.EnderecoId);

            HasRequired(p => p.Aluno)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(c => c.AlunoId);

            ToTable("EnderecoAluno");
        }
    }
}