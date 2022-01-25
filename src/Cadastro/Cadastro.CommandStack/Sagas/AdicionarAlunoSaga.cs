using Cadastro.CommandStack.Commands;
using Cadastro.CommandStack.Events;
using Cadastro.Data.Repository;
using Cadastro.Domain.Alunos;
using Cadastro.EventSourcing;
using Core.Infra.CQRS;
using Core.Infra.CQRS.EventStore;
using Core.Infra.CQRS.Repositories;

namespace Cadastro.CommandStack.Sagas
{
    public class AdicionarAlunoSaga : Saga,
            IStartWithMessage<AdicionarAlunoCommand>,
            IHandleMessage<AtualizarAlunoCommand>
    {
        private readonly IRepository _repository;

        public AdicionarAlunoSaga(IBus bus, IEventStore eventStore)
            : base(bus, eventStore)
        {
            _repository = new AlunoRepository();
        }

        public AdicionarAlunoSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore)
        {
            _repository = repository;
        }

        public void Handle(AdicionarAlunoCommand message)
        {
            var request = Aluno.Factory.NovoAluno(
                message.AlunoId,
                message.Nome,
                message.CPF,
                message.Email);

            var response = _repository.CreateFromRequest(request);
            if (!response.Success)
            {
                var rejected = new AdicionarAlunoRejeicaoEvent(request.AlunoId.Id, response.Description);
                Bus.RaiseEvent(rejected);
                return;
            }

            var alunoInfo = AlunoInfo.DomainToInfo(request);
            var created = new AdicionarAlunoConfirmacaoEvent(request.AlunoId.Id, response.AggregateId, alunoInfo);
            Bus.RaiseEvent(created);
        }

        public void Handle(AtualizarAlunoCommand message)
        {
            var request = Aluno.Factory.NovoAluno(
                message.AlunoId,
                message.Nome,
                message.CPF,
                message.Email);

            var response = _repository.Update(request);
            if (response.Success)
            {
                var alunoInfo = AlunoInfo.DomainToInfo(request);
                var atualizado = new AtualizarAlunoConfirmacaoEvent(request.AlunoId.Id, response.AggregateId, alunoInfo);
                Bus.RaiseEvent(atualizado);
            }
        }
    }
}