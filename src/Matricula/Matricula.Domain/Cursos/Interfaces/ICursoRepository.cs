using System;

namespace Matricula.Domain.Cursos.Interfaces
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        Curso ObterPorId(Guid id);
    }
}