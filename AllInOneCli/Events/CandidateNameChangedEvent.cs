using System;
using AllInOneCli.Base;

namespace AllInOneCli.Events
{
	[Serializable]
	public class CandidateNameChangedEvent : DomainEvent
	{
		public string Name { get; set; }

		public CandidateNameChangedEvent(String name)
		{
			Name = name;
		}
	}
}
