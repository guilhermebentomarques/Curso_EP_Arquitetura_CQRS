using System;
using Core.Domain;

namespace Matricula.Domain.Instrutores
{
    public class InstrutorId : Aggregate
    {
        public InstrutorId()
        {

        }

        public InstrutorId(Guid id) : base(id)
        {

        }
    }
}