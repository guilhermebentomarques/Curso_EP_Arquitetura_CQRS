using System;

namespace Cadastro.QueryStack.Models
{
    public class AlunoEndereco
    {
        public Guid AlunoId { get; set; }
        public Guid RequestId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
    }
}