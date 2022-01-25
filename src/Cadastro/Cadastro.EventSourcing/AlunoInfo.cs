using System;
using Cadastro.Domain.Alunos;

namespace Cadastro.EventSourcing
{
    public class AlunoInfo
    {
        public string Action { get; set; }
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime When { get; set; }


        public static AlunoInfo DomainToInfo(Aluno aluno)
        {
            var alunoEndereco = new AlunoInfo()
            {
                AlunoId = aluno.AlunoId.Id,
                CPF = aluno.CPF.Numero,
                Email = aluno.Email,
                Nome = aluno.Nome,
                When = DateTime.Now
            };

            return alunoEndereco;
        }
    }
}