using System;

namespace Matricula.Domain.Cursos.Interfaces
{
    public interface ICursoService
    {
        void Adicionar(Curso curso);
        Curso ObterPorId(Guid id); 
    }
}