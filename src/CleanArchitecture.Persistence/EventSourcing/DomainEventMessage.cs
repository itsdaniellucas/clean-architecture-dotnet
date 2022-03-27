using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.EventSourcing
{
    public class DomainEventMessage
    {
        public string EventName { get; set; }
        public DateTime EventTime { get; } = DateTime.Now;
        public object EventData { get; set; }
    }
}
