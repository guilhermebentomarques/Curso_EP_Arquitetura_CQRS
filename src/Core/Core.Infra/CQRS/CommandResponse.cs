using System;

namespace Core.Infra.CQRS
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false, Guid aggregateId = new Guid())
        {
            Success = success;
            AggregateId = aggregateId;
            Description = string.Empty;
        }

        public bool Success { get; private set; }
        public Guid AggregateId { get; private set; }
        public Guid RequestId { get; set; }
        public string Description { get; set; }
    }
}