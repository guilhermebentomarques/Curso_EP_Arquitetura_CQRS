using Cadastro.Domain.Alunos.Interfaces;
using Cadastro.Domain.Alunos.Validations.Alunos;

namespace Cadastro.Domain.Alunos.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            if (!aluno.IsValid())
                return aluno;

            aluno.ValidationResult = new AlunoAptoParaCadastroValidation(_alunoRepository).Validate(aluno);

            return aluno;
        }


        public Aluno Atualizar(Aluno aluno)
        {
            if (!aluno.IsValid())
                return aluno;

            // Validações para edição

            return aluno;
        }
    }
}