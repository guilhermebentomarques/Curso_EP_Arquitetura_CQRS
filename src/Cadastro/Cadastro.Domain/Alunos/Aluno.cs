using System;
using Cadastro.Domain.Alunos.Validations.Alunos;
using Core.Domain;
using DomainValidation.Validation;

namespace Cadastro.Domain.Alunos
{
    public class Aluno
    {
        public AlunoId AlunoId { get; private set; }
        public string Nome { get; private set; }
        public CPF CPF { get; private set; }
        public bool Ativo { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Email { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new AlunoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
        public void DefinirEndereco(Endereco endereco)
        {
            // Validacao
            Endereco = endereco;
        }

        public void Ativar()
        {
            // Validacao
            Ativo = true;
        }

        public static class Factory
        {
            public static Aluno NovoAluno(Guid alunoId, string nome, string cpf, string email)
            {

                var aluno = new Aluno()
                {
                    AlunoId = new AlunoId(alunoId),
                    Nome = nome,
                    CPF = new CPF(){Numero = cpf},
                    Email = email
                };

                return aluno;
            }
        }
    }
}
