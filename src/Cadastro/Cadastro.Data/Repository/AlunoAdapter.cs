using Cadastro.Data.Pocos;
using Cadastro.Domain.Alunos;
using Cadastro.QueryStack.Models;

namespace Cadastro.Data.Repository
{
    public class AlunoAdapter
    {
        public static AlunoPoco DomainToPoco(Aluno aluno)
        {
            var alunoPoco = new AlunoPoco()
            {
                AlunoId = aluno.AlunoId.Id,
                CPF = aluno.CPF.Numero,
                Email = aluno.Email,
                Nome = aluno.Nome,
                Ativo = false
            };

            return alunoPoco;
        }

        public static Aluno PocoToDomain(AlunoPoco alunoPoco)
        {
            return alunoPoco == null ? null : Aluno.Factory.NovoAluno(alunoPoco.AlunoId, alunoPoco.Nome, alunoPoco.CPF, alunoPoco.Email);
        }

        public static AlunoEndereco PocoToReadModel(AlunoPoco alunoPoco)
        {
            var alunoEndereco = new AlunoEndereco()
            {
                AlunoId = alunoPoco.AlunoId,
                CPF = alunoPoco.CPF,
                Email = alunoPoco.Email,
                Nome = alunoPoco.Nome,
                Ativo = false
            };

            return alunoEndereco;
        }
    }
}