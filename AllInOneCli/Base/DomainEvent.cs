using System;

namespace AllInOneCli.Base
{
	[Serializable]
	public class DomainEvent : IDomainEvent
	{
		public Guid ID { get; private set; }
		public Guid AggregateID { get; set; }
		public int Version { get; set; }

		public DomainEvent()
		{
			ID = Guid.NewGuid();
		}
	}
}
