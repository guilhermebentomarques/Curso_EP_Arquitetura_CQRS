using System;
using Core.Domain;

namespace Matricula.Domain.Cursos
{
    public class CursoId : Aggregate
    {
        public CursoId()
        {
            
        }

        public CursoId(Guid id) : base(id)
        {
            
        }
    }
}