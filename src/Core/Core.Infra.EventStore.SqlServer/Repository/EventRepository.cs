using System;
using System.Collections.Generic;
using System.Linq;
using Core.Infra.EventStore.SqlServer.Context;

namespace Core.Infra.EventStore.SqlServer.Repository
{
    public class EventRepository
    {
        private readonly EscolaEventStoreContext _db = new EscolaEventStoreContext();

        public void Store(LoggedEvent eventToLog)
        {
            eventToLog.TimeStamp = DateTime.Now;
            _db.LoggedEvents.Add(eventToLog);
            _db.SaveChanges();
        }

        public IList<LoggedEvent> All(Guid aggregateId)
        {
            var events = (from e in _db.LoggedEvents where e.AggregateId == aggregateId select e).ToList();
            return events;
        }
    }
}