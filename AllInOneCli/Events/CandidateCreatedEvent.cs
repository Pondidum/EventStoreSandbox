using System;
using AllInOneCli.Base;
using AllInOneCli.Domain;

namespace AllInOneCli.Events
{
	public class CandidateCreatedEvent : DomainEvent
	{
		public Guid CandidateID { get; private set; }
		public string Name { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public Sexes Sex { get; private set; }

		public CandidateCreatedEvent(Guid candidatID, String name, Sexes sex, DateTime dob)
		{
			CandidateID = candidatID;
			Name = name;
			Sex = sex;
			DateOfBirth = dob;
		}
	}
}
