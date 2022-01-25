using System;
using Core.Infra.CQRS;

namespace Cadastro.CommandStack.Commands
{
    public class AtualizarAlunoCommand : Command
    {
        public AtualizarAlunoCommand(Guid aluno, string nome, string cpf, string email)
        {
            Name = "AtualizarAluno";
            AlunoId = aluno;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        public Guid AlunoId { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
    }
}
