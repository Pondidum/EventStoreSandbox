using System;
using System.Collections.Generic;
using System.Linq;
using RelationalRefactorEventStore.Core;
using RelationalRefactorEventStore.Entities.Events;

namespace RelationalRefactorEventStore.Entities
{
	public class Candidate : Eventity
	{
		public String Name { get; private set; }
		public Sexes Sex { get; private set; }
		public DateTime DateOfBirth { get; private set; }

		private readonly List<Address> _addresses;

		public Candidate()
		{
			_addresses = new List<Address>();

			RegisterEvent<CandidateNameChangedEvent>(OnCandidateNameChanged);
			RegisterEvent<CandidateCreatedEvent>(OnCandidateCreated);
			
			RegisterEvent<CandidateAddressAddedEvent>(OnCandidateAddressAdded);
			RegisterEvent<CandidateAddressCorrectedEvent>(OnCandidateAddressCorrected);
			RegisterEvent<CandidateRemovedAddressEvent>(OnCandidateRemovedAddress);
		}


		public Candidate(String name, Sexes sex, DateTime dob) : this()
		{
			Apply(new CandidateCreatedEvent(Guid.NewGuid(), name, sex, dob));
		}

		public void ChangeCandidateName(String newName)
		{
			Apply(new CandidateNameChangedEvent(newName));
		}



		public void AddNewAddress(String line1, String line2, String line3, String town, String county, String postCode, String country, AddressTypes type)
		{
			Apply(new AddressEvent(Guid.NewGuid(), line1, line2, line3, town, county, postCode, country, type));
		}

		public void CorrectAddress(Guid addressID, String line1, String line2, String line3, String town, String county, String postCode, String country, AddressTypes type)
		{
			Apply(new CandidateAddressCorrectedEvent(addressID, line1, line2, line3, town, county, postCode, country, type));
		}

		public void RemoveAddress(Guid addressID)
		{
			Apply(new CandidateRemovedAddressEvent(addressID));
		}



		void OnCandidateRemovedAddress(CandidateRemovedAddressEvent e)
		{
			var address = _addresses.FirstOrDefault(a => a.ID == e.AddressID);
			_addresses.Remove(address);
		}

		void OnCandidateAddressCorrected(CandidateAddressCorrectedEvent e)
		{
			_addresses.First(a => a.ID == e.AddressID).AddressCorrected(e);
		}

		void OnCandidateAddressAdded(CandidateAddressAddedEvent e)
		{	
			_addresses.Add(new Address(e));
		}

		void OnCandidateCreated(CandidateCreatedEvent e)
		{
			ID = e.CandidateID;
			Name = e.Name;
			Sex = e.Sex;
			DateOfBirth = e.DateOfBirth;
		}

		private void OnCandidateNameChanged(CandidateNameChangedEvent e)
		{
			Name = e.Name;
		}
	}
}
