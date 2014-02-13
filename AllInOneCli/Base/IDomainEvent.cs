using System;

namespace AllInOneCli.Base
{
	public interface IDomainEvent
	{
		Guid ID { get; }
		Guid AggregateID { get; set; }
		int Version { get; set; }
	}
}
