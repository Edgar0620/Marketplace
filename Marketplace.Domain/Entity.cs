using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public abstract class Entity
    {
        private readonly List<Object> _events;
        protected Entity()=>_events = new List<Object>();
        protected void Apply(Object @event)
        {
            When(@event);
            EnsureValidState();
            _events.Add(@event);
        }
        protected abstract void When(Object @event);
        public IEnumerable<Object> GetChanges()=> _events.AsEnumerable();
        public void ClearChanges()=> _events.Clear();
        protected abstract void EnsureValidState();
    }
}
