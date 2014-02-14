using System.Collections.Generic;

namespace RelationalRefactorEventStore.Core
{
	public interface IEventSource
	{
		void Load(IEnumerable<Event> events);
		IEnumerable<Event> GetChanges();
		void ClearChanges();
	}
}
