using Cadastro.CommandStack.Handlers;
using Cadastro.CommandStack.Sagas;
using Core.Infra.CQRS;
using Core.Infra.CQRS.EventStore;

namespace Cadastro.Application.Bus
{
    public class BusConfig
    {
        public static IBus Bus { get; set; }
        public static void Initialize()
        {
            Bus = new InMemoryBus(new SqlEventStore());

            Bus.RegisterSaga<AdicionarAlunoSaga>();
            Bus.RegisterHandler<AdicionarAlunoRejeicaoHandler>();
            Bus.RegisterHandler<EmailHandler>();
        }
    }
}