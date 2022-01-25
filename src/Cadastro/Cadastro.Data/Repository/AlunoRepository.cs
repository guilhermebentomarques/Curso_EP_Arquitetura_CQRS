using System;
using System.Data.Entity;
using System.Linq;
using Cadastro.Data.Context;
using Cadastro.Data.Pocos;
using Cadastro.Domain.Alunos;
using Cadastro.Domain.Alunos.Interfaces;
using Cadastro.QueryStack.Context;
using Cadastro.QueryStack.Models;
using Core.Infra.CQRS;
using Core.Infra.CQRS.Repositories;

namespace Cadastro.Data.Repository
{
    public class AlunoRepository : IAlunoRepository, IRepository
    {
        private readonly AlunoContext _db;
        private readonly AlunoReadContext _dbRead;

        public AlunoRepository()
        {
            _db = new AlunoContext();
            _dbRead = new AlunoReadContext();
        }

        public int Adicionar(Aluno aluno)
        {
            var alunoPoco = AlunoAdapter.DomainToPoco(aluno);
            _db.Alunos.Add(alunoPoco);

            _dbRead.AlunoEnderecos.Add(AlunoAdapter.PocoToReadModel(alunoPoco));
            _dbRead.SaveChanges();

            return _db.SaveChanges();
        }

        public Aluno ObterPorId(Guid id)
        {
            return AlunoAdapter.PocoToDomain(_db.Alunos.Find(id));
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return AlunoAdapter.PocoToDomain(_db.Alunos.FirstOrDefault(a=>a.CPF == cpf));
        }

        public Aluno ObterPorEmail(string email)
        {
            return AlunoAdapter.PocoToDomain(_db.Alunos.FirstOrDefault(a => a.Email == email));
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public CommandResponse CreateFromRequest<T>(T item) where T : class
        {
            var request = item as Aluno;
            var count = Adicionar(request);

            var alunoPoco = AlunoAdapter.DomainToPoco(request);

            var response = new CommandResponse(count > 0, alunoPoco.AlunoId) { RequestId = alunoPoco.RequestId };
            return response;
        }

        public CommandResponse Update<T>(T item) where T : class
        {
            var request = item as Aluno;
            var alunoPoco = AlunoAdapter.DomainToPoco(request);

            var entry = _db.Entry(alunoPoco);
            _db.Set<AlunoPoco>().Attach(alunoPoco);
            entry.State = EntityState.Modified;
            var returnAluno = _db.SaveChanges();

            // TODO: Separar update da base de leitura em evento separado
            AtualizarAlunoEndereco(AlunoAdapter.PocoToReadModel(alunoPoco));
            
            return returnAluno == 0 ? CommandResponse.Fail : new CommandResponse(true,alunoPoco.AlunoId);
        }

        internal void AtualizarAlunoEndereco(AlunoEndereco alunoEndereco)
        {
            _dbRead.AlunoEnderecos.Remove(_dbRead.AlunoEnderecos.Find(alunoEndereco.AlunoId));

            _dbRead.AlunoEnderecos.Add(alunoEndereco);
            _dbRead.SaveChanges();
        }
    }
}