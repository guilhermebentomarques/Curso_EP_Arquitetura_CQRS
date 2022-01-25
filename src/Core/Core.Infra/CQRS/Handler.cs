using System;
using Core.Infra.CQRS.EventStore;

namespace Core.Infra.CQRS
{
    public abstract class Handler
    {
        public IEventStore EventStore { get; private set; }


        public Handler(IEventStore eventStore)
        {
            if (eventStore == null)
            {
                throw new ArgumentNullException("eventStore");
            }

            EventStore = eventStore;
        }
    }
}