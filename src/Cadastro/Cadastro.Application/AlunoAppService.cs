using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Cadastro.Application.Adapters;
using Cadastro.Application.Bus;
using Cadastro.Application.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.CommandStack.Commands;
using Cadastro.CommandStack.Events;
using Cadastro.Domain.Alunos.Interfaces;
using Cadastro.EventSourcing;
using Cadastro.QueryStack.Interfaces;
using Cadastro.QueryStack.Models;
using Core.Infra.EventStore.SqlServer.Repository;

namespace Cadastro.Application
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoService _alunoService;
        private readonly IAlunoReadRepository _alunoReadRepository;

        public AlunoAppService(IAlunoService alunoService, IAlunoReadRepository alunoReadRepository)
        {
            _alunoService = alunoService;
            _alunoReadRepository = alunoReadRepository;
        }

        public AlunoViewModel Adicionar(AlunoViewModel alunoViewModel)
        {
            var aluno = AlunoAdapter.ToDomainModel(alunoViewModel);

            var result = _alunoService.Adicionar(aluno);

            if (result.ValidationResult.IsValid)
            {
                var command = new AdicionarAlunoCommand(
                    alunoViewModel.AlunoId,
                    alunoViewModel.Nome,
                    alunoViewModel.CPF,
                    alunoViewModel.Email);

                BusConfig.Bus.Send(command);
            }

            alunoViewModel.ValidationResult = result.ValidationResult;
            return alunoViewModel;
        }

        public AlunoViewModel Atualizar(AlunoViewModel alunoViewModel)
        {
            var aluno = AlunoAdapter.ToDomainModel(alunoViewModel);

            var result = _alunoService.Atualizar(aluno);

            if (result.ValidationResult.IsValid)
            {
                var command = new AtualizarAlunoCommand(
                    alunoViewModel.AlunoId,
                    alunoViewModel.Nome,
                    alunoViewModel.CPF,
                    alunoViewModel.Email);

                BusConfig.Bus.Send(command);
            }

            alunoViewModel.ValidationResult = result.ValidationResult;
            return alunoViewModel;
        }

        public AlunoViewModel ObterPorId(Guid id)
        {
            return AlunoAdapter.ToViewModel(_alunoReadRepository.ObterPorId(id));
        }

        public IEnumerable<AlunoEndereco> ObterTodos()
        {
            return _alunoReadRepository.ObterTodos();
        }

        public AlunoHistory AlunoHistory(Guid aggregateId)
        {
            var serializer = new JavaScriptSerializer();
            var history = new AlunoHistory() { AlunoId = aggregateId };

            var events = new EventRepository().All(aggregateId);
            foreach (var e in events)
            {
                var slot = new AlunoInfo();
                dynamic values;
                switch (e.Action)
                {
                    case "AdicionarAlunoConfirmacaoEvent":
                        values = serializer.Deserialize<dynamic>(e.Cargo);
                        slot.CPF = values["Data"]["CPF"];
                        slot.Email = values["Data"]["Email"];
                        slot.Nome = values["Data"]["Nome"];
                        slot.Action = "Criado";
                        slot.When = Convert.ToDateTime(values["When"]);
                        slot.AlunoId = Guid.Parse(values["Id"]);
                        break;
                    case "AtualizarAlunoConfirmacaoEvent":
                        values = serializer.Deserialize<dynamic>(e.Cargo);
                        slot.CPF = values["Data"]["CPF"];
                        slot.Email = values["Data"]["Email"];
                        slot.Nome = values["Data"]["Nome"];
                        slot.Action = "Modificado";
                        slot.When = Convert.ToDateTime(values["When"]);
                        slot.AlunoId = Guid.Parse(values["Id"]);
                        break;
                }

                history.Modificacoes.Add(slot);
            }
            return history;
        }
    }
}