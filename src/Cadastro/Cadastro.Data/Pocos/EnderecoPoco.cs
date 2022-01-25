using System;

namespace Cadastro.Data.Pocos
{
    public class EnderecoPoco
    {
        public EnderecoPoco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }
        public Guid AlunoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public virtual AlunoPoco Aluno { get; set; }
    }
}