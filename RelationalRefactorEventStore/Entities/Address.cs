using System;
using RelationalRefactorEventStore.Core;
using RelationalRefactorEventStore.Entities.Events;

namespace RelationalRefactorEventStore.Entities
{
	public class Address : Eventity
	{
		public string Line1 { get; private set; }
		public string Line2 { get; private set; }
		public string Line3 { get; private set; }
		public string Town { get; private set; }
		public string County { get; private set; }
		public string PostCode { get; private set; }
		public string Country { get; private set; }
		public AddressTypes Type { get; private set; }

		public Address()
		{
			RegisterEvent<AddressEvent>(OnAddressCreated);
		}

		public Address(String line1, String line2, String line3, String town, String county, String postCode, String country, AddressTypes type) : this()
		{
			Apply(new AddressEvent(Guid.NewGuid(), line1, line2, line3, town, county, postCode, country, type));
		}

		public Address(AddressEvent e) : this()
		{
			Apply(e);
		}

		public void AddressCorrected(CandidateAddressCorrectedEvent e)
		{
			Apply(e);
		}




		private void OnAddressCreated(AddressEvent e)
		{
			ID = e.AddressID;
			Line1 = e.Line1;
			Line2 = e.Line2;
			Line3 = e.Line3;
			Town = e.Town;
			County = e.County;
			PostCode = e.PostCode;
			Country = e.Country;
			Type = e.Type;
		}

	}
}
