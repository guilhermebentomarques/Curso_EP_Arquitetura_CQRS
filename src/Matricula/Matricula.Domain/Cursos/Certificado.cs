using System;

namespace Matricula.Domain.Cursos
{
    public class Certificado
    {
        public Guid CertificadoId { get; private set; }
        public CursoId CursoId { get; private set; }
        public DateTime Emissao { get; private set; }
        public string NomeAluno { get; private set; }

        protected Certificado()
        {
            CertificadoId = Guid.NewGuid();
        }

        public string UriCertificado()
        {
            return CertificadoId.ToString();
        }

        public static class Factory
        {
            public static Certificado NovoCertificado(CursoId cursoId, DateTime emissao, string nomeAluno)
            {
                if (String.IsNullOrWhiteSpace(nomeAluno))
                    throw new ArgumentException("Can't be null or empty", "companyName");


                var certificado = new Certificado()
                {
                    CursoId = cursoId,
                    Emissao = emissao,
                    NomeAluno = nomeAluno
                };

                return certificado;
            }
        }
    }
}