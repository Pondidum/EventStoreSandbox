using System;
using System.Collections.Generic;
using RelationalRefactorOriginal.Core;
using RelationalRefactorOriginal.Entities;

namespace RelationalRefactorOriginal
{
	class Program
	{
		static void Main(string[] args)
		{
			var id = Guid.NewGuid();
			var row = new List<Object> { "Dave", Sexes.Male, new DateTime(1984, 4, 28) };

			Database.AddRow(id, row);

			var candidate = new Candidate();
			candidate.ID = id;
			candidate.Load();

		}
	}
}
