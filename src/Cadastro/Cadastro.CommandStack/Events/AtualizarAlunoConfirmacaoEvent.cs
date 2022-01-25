using System;
using Cadastro.EventSourcing;
using Core.Infra.CQRS;

namespace Cadastro.CommandStack.Events
{
    public class AtualizarAlunoConfirmacaoEvent : Event
    {
        public AtualizarAlunoConfirmacaoEvent()
        {
            
        }

        public AtualizarAlunoConfirmacaoEvent(Guid requestId, Guid id, AlunoInfo data)
        {
            RequestId = requestId;
            Id = id;
            Data = data;
            When = DateTime.Now;
            SagaId = id;
        }

        public Guid Id { get; private set; }
        public Guid RequestId { get; private set; }
        public DateTime When { get; private set; }
        public AlunoInfo Data { get; private set; }
    }
}