using Cadastro.Domain.Alunos.Interfaces;
using Cadastro.Domain.Alunos.Specifications.Alunos;
using DomainValidation.Validation;

namespace Cadastro.Domain.Alunos.Validations.Alunos
{
    public class AlunoAptoParaCadastroValidation : Validator<Aluno>
    {
        public AlunoAptoParaCadastroValidation(IAlunoRepository alunoRepository)
        {
            var cpfDuplicado = new AlunoDevePossuirCPFUnicoSpecification(alunoRepository);
            var emailDuplicado = new AlunoDevePossuirEmailUnicoSpecification(alunoRepository);

            base.Add("cpfDuplicado", new Rule<Aluno>(cpfDuplicado, "CPF já cadastrado!"));
            base.Add("emailDuplicado", new Rule<Aluno>(emailDuplicado, "E-mail já cadastrado!"));
        }
    }
}