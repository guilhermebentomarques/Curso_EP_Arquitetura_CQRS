using Cadastro.Application.ViewModels;
using Cadastro.Domain;
using Cadastro.Domain.Alunos;
using Cadastro.QueryStack.Models;

namespace Cadastro.Application.Adapters
{
    public class AlunoAdapter
    {
        public static Aluno ToDomainModel(AlunoViewModel alunoViewModel)
        {
            var aluno = Aluno.Factory.NovoAluno(
                alunoViewModel.AlunoId,
                alunoViewModel.Nome,
                alunoViewModel.CPF,
                alunoViewModel.Email);
            
            return aluno;
        }

        public static AlunoViewModel ToViewModel(AlunoEndereco alunoEndereco)
        {
            var aluno = new AlunoViewModel()
            {
                AlunoId = alunoEndereco.AlunoId,
                Nome = alunoEndereco.Nome,
                CPF = alunoEndereco.CPF,
                Email = alunoEndereco.Email
            };

            return aluno;
        }
    }
}