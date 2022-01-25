namespace Core.Infra.CQRS.Repositories
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : class;

        CommandResponse CreateFromRequest<T>(T item) where T : class;

        CommandResponse Update<T>(T item) where T : class;
    }
}