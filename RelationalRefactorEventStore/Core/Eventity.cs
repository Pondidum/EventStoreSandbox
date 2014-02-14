using System;
using System.Collections.Generic;
using System.Linq;

namespace RelationalRefactorEventStore.Core
{
	public class Eventity : IEventSource
	{
		public Guid ID { get; set; }
		public int Version { get; private set; }

		private readonly Dictionary<Type, Action<Event>> _registeredEvents;
		private readonly List<Event> _appliedEvents;

		public Eventity()
		{
			_registeredEvents = new Dictionary<Type, Action<Event>>();
			_appliedEvents = new List<Event>();
		}

		void IEventSource.Load(IEnumerable<Event> events)
		{
			var stream = events.OrderBy(e => e.Version).ToList();

			foreach (var e in stream)
			{
				Apply(e.GetType(), e);
			}

			Version = stream.Last().Version;
		}

		IEnumerable<Event> IEventSource.GetChanges()
		{
			return _appliedEvents;
		}

		void IEventSource.ClearChanges()
		{
			_appliedEvents.Clear();
		}

		protected void RegisterEvent<T>(Action<T> handler) where T : Event
		{
			_registeredEvents[typeof(T)] = e => handler((T) e);
		}

		protected void Apply<T>(T @event) where T : Event
		{
			@event.EntityID = ID;
			@event.Version = GetNextVersion();

			Apply(@event.GetType(), @event);

			_appliedEvents.Add(@event);
		}

		private void Apply(Type eventType, Event @event)
		{
			Action<Event> handler;

			if (_registeredEvents.TryGetValue(eventType, out handler) == false)
			{
				throw new EventNotRegisteredException(eventType.FullName, GetType().FullName);
			}

			handler(@event);
		}

		private int GetNextVersion()
		{
			return ++Version;
		}

	}
}
