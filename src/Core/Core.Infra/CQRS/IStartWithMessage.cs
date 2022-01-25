namespace Core.Infra.CQRS
{
    public interface IStartWithMessage<in T> where T : Message
    {
        void Handle(T message);
    }
}