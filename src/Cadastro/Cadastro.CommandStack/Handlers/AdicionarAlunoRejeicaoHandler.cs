using Cadastro.CommandStack.Events;
using Core.Infra.CQRS;
using Core.Infra.CQRS.EventStore;

namespace Cadastro.CommandStack.Handlers
{
    public class AdicionarAlunoRejeicaoHandler : Handler,
        IHandleMessage<AdicionarAlunoRejeicaoEvent>
    {
        public AdicionarAlunoRejeicaoHandler(IEventStore eventStore) 
            : base(eventStore)
        {
        }

        public void Handle(AdicionarAlunoRejeicaoEvent message)
        {
            throw new System.NotImplementedException();
        }
    }
}