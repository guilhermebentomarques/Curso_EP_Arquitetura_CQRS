using System.Data.Entity.ModelConfiguration;
using Cadastro.Data.Pocos;

namespace Cadastro.Data.EntityConfig
{
    public class AlunoEmailsEnviadosConfig : EntityTypeConfiguration<AlunoEmailsEnviados>
    {
        public AlunoEmailsEnviadosConfig()
        {
            HasKey(e => e.Id);

            ToTable("AlunoEmailsEnviados");
        }
    }
}