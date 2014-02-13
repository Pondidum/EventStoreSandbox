using System;
using System.Collections.Generic;

namespace AllInOneCli.Base
{
	public class Entity<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		private Func<int> _versionProvider;
		private readonly Dictionary<Type, Action<TDomainEvent>> _events;
		private readonly List<TDomainEvent> _appliedEvents;

		public Entity()
		{
			_events = new Dictionary<Type, Action<TDomainEvent>>();
			_appliedEvents = new List<TDomainEvent>();
		}

		public Guid ID { get; protected set; }


		protected void RegisterEvent<TEvent>(Action<TEvent> eventHandler) where TEvent : class, TDomainEvent
		{
			_events.Add(typeof(TEvent), theEvent => eventHandler(theEvent as TEvent));
		}

		public void Load<TEvent>(IEnumerable<TEvent> eventStream) where TEvent : class, TDomainEvent
		{
			foreach (var domainEvent in eventStream)
			{
				Apply(domainEvent.GetType(), domainEvent);
			}
		}

		public IEnumerable<TDomainEvent> GetChanges()
		{
			return _appliedEvents;
		}

		public void ClearChanges()
		{
			_appliedEvents.Clear();
		}

		protected void Apply<TEvent>(TEvent domainEvent) where TEvent : class, TDomainEvent
		{
			domainEvent.AggregateID = ID;
			domainEvent.Version = _versionProvider();

			Apply(domainEvent.GetType(), domainEvent);

			_appliedEvents.Add(domainEvent);
		}

		private void Apply(Type eventType, TDomainEvent domainEvent)
		{
			Action<TDomainEvent> handler;

			if (_events.TryGetValue(eventType, out handler) == false)
			{
				throw new UnregisteredDomainEventException(eventType.FullName, GetType().FullName);
			}

			handler(domainEvent);
		}
	}
}
