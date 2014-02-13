using System;

namespace RelationalRefactorEventStore.Core
{
	[Serializable]
	public class Event
	{
		public Guid EventID { get; private set; }
		public Guid EntityID { get; set; }
		public int Version { get; set; }

		public Event()
		{
			EventID = Guid.NewGuid();
		}
	}
}
