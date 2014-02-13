using System;

namespace RelationalRefactorEventStore.Core
{
	public class EventNotRegisteredException : Exception
	{
		public EventNotRegisteredException(string eventType, string entityType)
			: base(string.Format("Event '{0}' was not registered on '{1}'.", eventType, entityType))
		{
		}
	}
}
