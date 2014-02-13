using System;
using System.Collections.Generic;
using System.Linq;

namespace RelationalRefactorEventStore.Core
{
	public class EventStore
	{
		private static readonly Dictionary<Type, List<Event>> Events;

		static EventStore()
		{
			Events = new Dictionary<Type, List<Event>>();
		}

		public static IEnumerable<Event> GetStreamFor(Type type, Guid id)
		{
			return Events[type].Where(e => e.EntityID == id).OrderBy(e => e.Version);
		}

		public static void AddEventFor<T>(Guid id, Event @event)
		{
			var type = typeof (T);

			if (Events.ContainsKey(type) == false)
			{
				Events.Add(type, new List<Event>());
			}

			@event.EntityID = id;
			Events[typeof(T)].Add(@event);
		}
	}
}
