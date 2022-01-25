using Cadastro.CommandStack.Events;
using Cadastro.Infra.Utils;
using Core.Infra.CQRS;
using Core.Infra.CQRS.EventStore;

namespace Cadastro.CommandStack.Handlers
{
    public class EmailHandler : Handler,
        IHandleMessage<AdicionarAlunoRejeicaoEvent>,
        IHandleMessage<AdicionarAlunoConfirmacaoEvent>,
        IHandleMessage<AtualizarAlunoConfirmacaoEvent>
    {
        public EmailHandler(IEventStore eventStore)
            : base(eventStore)
        {

        }

        public void Handle(AdicionarAlunoRejeicaoEvent message)
        {
            var body = string.Format("Sua solicitação {0} não pode ser completada.",
                message.RequestId);
            EmailService.Send("user@company.com", body);
        }

        public void Handle(AdicionarAlunoConfirmacaoEvent message)
        {
            var body = string.Format("Parabéns! Você foi registrado, protocolo número: {0}.",
                message.Id);
            EmailService.Send("user@company.com", body);
        }

        public void Handle(AtualizarAlunoConfirmacaoEvent message)
        {
            var body = string.Format("Seu cadastro foi atualizado, protocolo número: {0}.",message.Id);
            EmailService.Send("user@company.com", body);
        }
    }
}