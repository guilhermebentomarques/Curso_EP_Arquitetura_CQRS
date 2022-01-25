using System;
using Core.Domain;

namespace Matricula.Domain.Cursos
{
    public class Curso
    {
        public CursoId CursoId { get; private set; }
        public string Nome { get; private set; }
        public int CargaHoraria { get; internal set; }
        public int QuantidadeAlunos { get; internal set; }
        public Periodo Periodo { get; internal set; }
        public Nivel Nivel { get; private set; }
        public Certificado Certificado { get; internal set; }

        private Curso()
        {
        }

        public static class Factory
        {
            public static Curso NovoCurso(CursoId cursoId, string nome, int cargaHoraria, int quantidadeAlunos, Periodo periodo, Nivel nivel, Certificado certificado)
            {
                if (string.IsNullOrWhiteSpace(nome))
                    throw new ArgumentException("Can't be null or empty", "nome");

                var curso = new Curso()
                {
                    CursoId = cursoId,
                    Nome = nome,
                    CargaHoraria = cargaHoraria,
                    QuantidadeAlunos = quantidadeAlunos,
                    Periodo = periodo,
                    Nivel = nivel,
                    Certificado = certificado
                };

                return curso;
            }
        }
    }
}
