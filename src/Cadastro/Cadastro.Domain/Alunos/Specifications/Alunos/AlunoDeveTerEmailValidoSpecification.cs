using Cadastro.Domain.Alunos.Validations.Documentos;
using DomainValidation.Interfaces.Specification;

namespace Cadastro.Domain.Alunos.Specifications.Alunos
{
    public class AlunoDeveTerEmailValidoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return EmailValidation.Validate(aluno.Email);
        }
    }
}