using System;
using System.Collections.Generic;

namespace Cadastro.EventSourcing
{
    public class JavaScriptAlunoHistory
    {
        public Guid AlunoId { get; set; }
        public IList<JavaScriptAlunoInfo> Modificacoes { get; set; }
    }
}