using System;
using Core.Infra.CQRS.EventStore;

namespace Core.Infra.CQRS
{
    public abstract class Saga
    {
        public IBus Bus { get; private set; }
        public IEventStore EventStore { get; private set; }


        protected Saga(IBus bus, IEventStore eventStore)
        {
            if (bus == null)
            {
                throw new ArgumentNullException("bus");
            }

            Bus = bus;
            EventStore = eventStore;
        }
    }
}