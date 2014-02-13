using System;
using System.Collections.Generic;
using System.Linq;

namespace AllInOneCli.Base
{
	public class AggregateRoot<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		public Guid ID { get; protected set; }
		public int Version { get; protected set; }
		public int EventVersion { get; protected set; }

		private readonly Dictionary<Type, Action<TDomainEvent>> _registeredEvents;
		private readonly List<TDomainEvent> _appliedEvents;

		public AggregateRoot()
		{
			_registeredEvents = new Dictionary<Type,Action<TDomainEvent>>();
			_appliedEvents = new List<TDomainEvent>();
		}

		protected void RegisterEvent<TEvent>(Action<TEvent> eventHandler) where TEvent : class, TDomainEvent
		{
			_registeredEvents.Add(typeof(TEvent), theEvent => eventHandler(theEvent as TEvent));
		}

		public void Load<TEvent>(IEnumerable<TEvent> eventStream) where TEvent : class, TDomainEvent
		{
			var stream = eventStream.ToList();

			if (stream.Any() == false)
			{
				return;
			}

			foreach (var domainEvent in stream)
			{
				Apply(domainEvent.GetType(), domainEvent);
			}

			Version = stream.Last().Version;
			EventVersion = Version;
		}
		
		protected void Apply<TEvent>(TEvent domainEvent) where TEvent : class, TDomainEvent
		{
			domainEvent.AggregateID = ID;
			domainEvent.Version = GetNewEventVersion();

			Apply(domainEvent.GetType(), domainEvent);

			_appliedEvents.Add(domainEvent);
		}


		private void Apply(Type eventType, TDomainEvent domainEvent)
		{
			Action<TDomainEvent> handler;

			if (_registeredEvents.TryGetValue(eventType, out handler) == false)
			{
				throw new UnregisteredDomainEventException(eventType.FullName, GetType().FullName);
			}

			handler(domainEvent);
		}


		private int GetNewEventVersion()
		{
			return ++EventVersion;
		}

	}
}