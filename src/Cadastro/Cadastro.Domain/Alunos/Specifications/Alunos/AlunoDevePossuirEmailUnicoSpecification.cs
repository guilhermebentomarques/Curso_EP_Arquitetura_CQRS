using Cadastro.Domain.Alunos.Interfaces;
using DomainValidation.Interfaces.Specification;

namespace Cadastro.Domain.Alunos.Specifications.Alunos
{
    public class AlunoDevePossuirCPFUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoDevePossuirCPFUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorCpf(aluno.CPF.Numero) == null;
        }
    }
}