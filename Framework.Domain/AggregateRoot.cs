using Framework.Core.Messageing;
using System;
using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class AggregateRoot : Entity
    {
        private List<IEvent> _changes=new List<IEvent>();

        protected AggregateRoot(Guid id):base(id)
        {

        }

        protected AggregateRoot() { }



        public IReadOnlyCollection<IEvent> GetUnCommitedChanges()
        {
            return _changes;
        }

        public void CleareChanges()
        {
            _changes.Clear();
        }

        protected void AddChanges<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _changes.Add(@event);
        }
    }
}
