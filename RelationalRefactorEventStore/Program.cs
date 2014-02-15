using System;
using System.Linq;
using RelationalRefactorEventStore.Core;
using RelationalRefactorEventStore.Entities;

namespace RelationalRefactorEventStore
{
	class Program
	{
		static void Main(string[] args)
		{
			var candidate = new Candidate("Andy", Sexes.Male, new DateTime(1986, 2, 17));
			//candidate.ChangeCandidateName("Andy Dote");
			//candidate.AddNewAddress("Home", "", "", "Southampton", "Hampshire", "SO2", "UK", AddressTypes.Home);

			var events = ((IEventSource)candidate).GetChanges().ToList();

			events.ForEach(e => Console.WriteLine("{0} - {1}", e.Version, e.EntityID));

			Console.ReadKey();
		}


	}
}
