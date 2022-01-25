using System;

namespace Core.Infra.CQRS
{
    public class Message
    {
        public Guid SagaId { get; protected set; }
        public string Name { get; protected set; }
    }
}