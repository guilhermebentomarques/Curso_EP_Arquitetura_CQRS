using System;
using Core.Infra.CQRS;

namespace Cadastro.CommandStack.Commands
{
    public class AdicionarAlunoCommand : Command
    {
        public AdicionarAlunoCommand(Guid aluno, string nome, string cpf, string email)
        {
            Name = "AdicionarAluno";
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