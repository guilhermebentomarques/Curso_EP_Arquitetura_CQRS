using Cadastro.Application;
using Cadastro.Application.Interfaces;
using Cadastro.Data.Context;
using Cadastro.Data.Repository;
using Cadastro.Domain.Alunos.Interfaces;
using Cadastro.Domain.Alunos.Services;
using Cadastro.QueryStack.Context;
using Cadastro.QueryStack.Interfaces;
using Cadastro.QueryStack.Repository;
using SimpleInjector;

namespace Cadastro.Infra.IoC
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            // APP
            container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);
            container.Register<IAlunoReadRepository, AlunoReadRepository>(Lifestyle.Scoped);

            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<AlunoContext>(Lifestyle.Scoped);
            container.Register<AlunoReadContext>(Lifestyle.Scoped);
        }
    }
}