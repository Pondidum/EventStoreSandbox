using System;
using System.Collections.Generic;
using System.Linq;
using RelationalRefactorEventStore.Core;
using RelationalRefactorEventStore.Entities;
using RelationalRefactorEventStore.Entities.Events;

namespace RelationalRefactorEventStore
{
	class Program
	{
		static void Main(string[] args)
		{
			var id = Guid.NewGuid();
			
			EventStore.AddEventFor<Candidate>(id, new CandidateCreatedEvent(id, "Dave", Sexes.Male, new DateTime(1986, 4, 17)) { Version = 0});
			EventStore.AddEventFor<Candidate>(id, new CandidateNameChangedEvent("Davey") { Version = 1 });
			EventStore.AddEventFor<Candidate>(id, new CandidateNameChangedEvent("David") { Version = 2 });

			var candidate = new Candidate();
			candidate.ID = id;
			
			((IEventSource)candidate).Load(EventStore.GetStreamFor(candidate.GetType(), candidate.ID));

			var events = ((IEventSource) candidate).GetChanges().ToList();

		}
	}
}
