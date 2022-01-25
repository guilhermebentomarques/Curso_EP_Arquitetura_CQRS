using System;
using System.Collections.Generic;

namespace Cadastro.Data.Pocos
{
    public class AlunoPoco
    {
        public AlunoPoco()
        {
            AlunoId = Guid.NewGuid();
            RequestId = Guid.NewGuid();
        }
        
        public Guid AlunoId { get; set; }
        public Guid RequestId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<EnderecoPoco> Enderecos { get; set; }
        public string Email { get; set; } 
    }
}