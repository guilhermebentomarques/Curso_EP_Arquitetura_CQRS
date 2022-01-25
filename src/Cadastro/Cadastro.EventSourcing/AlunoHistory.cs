using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.EventSourcing
{
    public class AlunoHistory
    {
        public AlunoHistory()
        {
            Modificacoes = new List<AlunoInfo>();
        }

        public Guid AlunoId { get; set; }
        public IList<AlunoInfo> Modificacoes { get; set; }

        public JavaScriptAlunoHistory ToJavaScriptAlunoHistory()
        {
            var dto = new JavaScriptAlunoHistory()
            {
                AlunoId = AlunoId,
                Modificacoes = ToJavaScriptAlunoInfo(Modificacoes)
            };
            return dto;
        }

        private IList<JavaScriptAlunoInfo> ToJavaScriptAlunoInfo(IEnumerable<AlunoInfo> changes)
        {
            var sorted = changes.OrderBy(c => c.When);
            var list = new List<JavaScriptAlunoInfo>();
            var last = new AlunoInfo();
            foreach (var change in sorted)
            {
                var jsSlot = new JavaScriptAlunoInfo();
                jsSlot.AlunoId = change.AlunoId == Guid.Empty || change.AlunoId == last.AlunoId 
                    ? "" 
                    : change.AlunoId.ToString();
                jsSlot.Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                    ? ""
                    : change.Nome;
                jsSlot.Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                    ? ""
                    : change.Email;
                jsSlot.CPF = string.IsNullOrWhiteSpace(change.CPF) || change.CPF == last.CPF 
                    ? "" 
                    : change.CPF;

                jsSlot.Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action;
                jsSlot.When = change.When.ToString("dd MMM yyyy HH:mm");
                list.Add(jsSlot);
                
                // Save last change 
                last = change;
            }
            return list;
        }
    }
}