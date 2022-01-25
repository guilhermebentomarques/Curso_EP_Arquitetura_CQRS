using System;
using Core.Domain;

namespace Cadastro.Domain.Alunos
{
    public class AlunoId : Aggregate
    {
        public AlunoId()
        {
            
        }

        public AlunoId(Guid id) : base(id)
        {
            
        }
    }
}