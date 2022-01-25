using System;
using System.Collections.Generic;
using Cadastro.QueryStack.Models;

namespace Cadastro.QueryStack.Interfaces
{
    public interface IAlunoReadRepository
    {
        IEnumerable<AlunoEndereco> ObterTodos();
        AlunoEndereco ObterPorId(Guid id);
    }
}