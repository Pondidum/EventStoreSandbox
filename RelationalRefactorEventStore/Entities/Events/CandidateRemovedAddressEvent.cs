using System;
using RelationalRefactorEventStore.Core;

namespace RelationalRefactorEventStore.Entities.Events
{
	public class CandidateRemovedAddressEvent : Event
	{
		public Guid AddressID { get; set; }

		public CandidateRemovedAddressEvent(Guid addressID)
		{
			AddressID = addressID;
		}
	}
}
