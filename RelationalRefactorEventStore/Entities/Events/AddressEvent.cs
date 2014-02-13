using System;
using RelationalRefactorEventStore.Core;

namespace RelationalRefactorEventStore.Entities.Events
{
	public class AddressEvent : Event
	{
		public Guid AddressID { get; private set; }
		public string Line1 { get; private set; }
		public string Line2 { get; private set; }
		public string Line3 { get; private set; }
		public string Town { get; private set; }
		public string County { get; private set; }
		public string PostCode { get; private set; }
		public string Country { get; private set; }
		public AddressTypes Type { get; private set; }

		public AddressEvent(Guid addressID, String line1, String line2, String line3, String town, String county, String postCode, String country, AddressTypes type)
		{
			AddressID = addressID;
			Line1 = line1;
			Line2 = line2;
			Line3 = line3;
			Town = town;
			County = county;
			PostCode = postCode;
			Country = country;
			Type = type;
		}
	}
}
