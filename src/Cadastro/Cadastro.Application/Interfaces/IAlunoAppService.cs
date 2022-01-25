using System;
using System.Collections.Generic;
using Cadastro.Application.ViewModels;
using Cadastro.EventSourcing;
using Cadastro.QueryStack.Models;

namespace Cadastro.Application.Interfaces
{
    public interface IAlunoAppService
    {
        AlunoViewModel Adicionar(AlunoViewModel aluno);
        AlunoViewModel ObterPorId(Guid id);
        IEnumerable<AlunoEndereco> ObterTodos();
        AlunoViewModel Atualizar(AlunoViewModel aluno);
        AlunoHistory AlunoHistory(Guid aggregateId);
    }
}