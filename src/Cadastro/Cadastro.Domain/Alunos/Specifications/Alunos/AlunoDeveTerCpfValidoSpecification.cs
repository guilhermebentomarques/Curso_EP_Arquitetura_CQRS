using Cadastro.Domain.Alunos.Validations.Documentos;
using DomainValidation.Interfaces.Specification;

namespace Cadastro.Domain.Alunos.Specifications.Alunos
{
    public class AlunoDeveTerCpfValidoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return CPFValidation.Validar(aluno.CPF.Numero);
        }
    }
}