using System;
using AllInOneCli.Base;
using AllInOneCli.Domain.Mementos;
using AllInOneCli.Events;

namespace AllInOneCli.Domain
{
	public class Candidate : AggregateRoot<IDomainEvent>, IOriginator
	{
		private String _name;
		private DateTime _dob;
		private Sexes _sex;

		public Candidate()
		{
			RegisterEvent<CandidateCreatedEvent>(OnCandidateCreated);
			RegisterEvent<CandidateNameChangedEvent>(OnCandidateNameChanged);
		}

		private Candidate(String name, Sexes sex, DateTime dob) : this()
		{
			Apply(new CandidateCreatedEvent(Guid.NewGuid(), name, sex, dob));
		}

		public static Candidate CreateNew(String name, Sexes sex, DateTime dob)
		{
			return new Candidate(name, sex, dob);
		}

		IMemento IOriginator.CreateMemento()
		{
			return new CandidateMemento(_name, _sex, _dob);
		}

		void IOriginator.SetMemento(IMemento memento)
		{
			var candidate = (CandidateMemento) memento;

			_name = candidate.Name;
			_sex = candidate.Sex;
			_dob = candidate.DateOfBirth;
		}


		private void OnCandidateCreated(CandidateCreatedEvent eventData)
		{
			_name = eventData.Name;
			_dob = eventData.DateOfBirth;
			_sex = eventData.Sex;
		}

		private void OnCandidateNameChanged(CandidateNameChangedEvent eventData)
		{
			_name = eventData.Name;
		}
	}

	public enum Sexes
	{
		Unknown,
		Male,
		Female,
	}
}
