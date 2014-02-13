using System;
using RelationalRefactorEventStore.Core;

namespace RelationalRefactorEventStore.Entities.Events
{
	public class CandidateCreatedEvent : Event
	{
		public Guid CandidateID { get; private set; }
		public String Name { get; private set; }
		public Sexes Sex { get; private set; }
		public DateTime DateOfBirth { get; private set; }

		public CandidateCreatedEvent(Guid candidateID, String name, Sexes sex, DateTime dob)
		{
			CandidateID = candidateID;
			Name = name;
			Sex = sex;
			DateOfBirth = dob;
		}
	}
}