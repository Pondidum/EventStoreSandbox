using System;

namespace RelationalRefactorEventStore.Entities.Events
{
	public class CandidateAddressCorrectedEvent : AddressEvent
	{
		public CandidateAddressCorrectedEvent(Guid addressID, string line1, string line2, string line3, string town, string county, string postCode, string country, AddressTypes type)
			: base(addressID, line1, line2, line3, town, county, postCode, country, type)
		{
		}
	}
}