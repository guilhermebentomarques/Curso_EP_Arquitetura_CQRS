using System.Collections.Generic;
using System.Linq;
using Cadastro.QueryStack.Context;
using Cadastro.QueryStack.Interfaces;
using Cadastro.QueryStack.Models;
using Dapper;

namespace Cadastro.QueryStack.Repository
{
    public class AlunoReadRepository : IAlunoReadRepository
    {
        private readonly AlunoReadContext _db;

        public AlunoReadRepository(AlunoReadContext db)
        {
            _db = db;
        }

        public IEnumerable<AlunoEndereco> ObterTodos()
        {
            var cn = _db.Database.Connection;

            var sql = @"select * from AlunoEndereco";

            return cn.Query<AlunoEndereco>(sql);
        }

        public Models.AlunoEndereco ObterPorId(System.Guid id)
        {
            var cn = _db.Database.Connection;

            var sql = @"select * from AlunoEndereco " +
                      "where AlunoId = @sid";

            return cn.Query<AlunoEndereco>(sql, new {sid = id}).FirstOrDefault();
        }
    }
}