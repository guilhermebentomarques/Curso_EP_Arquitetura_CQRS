using Cadastro.Domain.Alunos.Interfaces;
using DomainValidation.Interfaces.Specification;

namespace Cadastro.Domain.Alunos.Specifications.Alunos
{
    public class AlunoDevePossuirEmailUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoDevePossuirEmailUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorEmail(aluno.Email) == null;
        }
    }
}