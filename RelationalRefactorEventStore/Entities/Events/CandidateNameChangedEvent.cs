using System;
using RelationalRefactorEventStore.Core;

namespace RelationalRefactorEventStore.Entities.Events
{
	public class CandidateNameChangedEvent : Event
	{
		public String Name { get; private set; }

		public CandidateNameChangedEvent(String name)
		{
			Name = name;
		}
	}
}