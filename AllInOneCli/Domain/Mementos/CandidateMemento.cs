using System;

namespace AllInOneCli.Domain.Mementos
{
	public class CandidateMemento : IMemento
	{
		public String Name { get; private set; } 
		public Sexes Sex { get; private set; }
		public DateTime DateOfBirth { get; private set; }

		public CandidateMemento(String name, Sexes sex, DateTime dob)
		{
			Name = name;
			Sex = sex;
			DateOfBirth = dob;
		}
	}
}
