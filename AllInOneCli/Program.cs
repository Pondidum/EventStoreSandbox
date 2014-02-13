using System;
using AllInOneCli.Domain;

namespace AllInOneCli
{
	class Program
	{
		static void Main(string[] args)
		{
			var candidate = Candidate.CreateNew("Dave", Sexes.Male, new DateTime(1986, 5, 27));
		}
	}
}
