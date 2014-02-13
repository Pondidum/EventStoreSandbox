using System;
using System.Collections.Generic;

namespace RelationalRefactorOriginal.Core
{
	public class Database
	{
		static readonly Dictionary<Guid, List<Object>> Rows;

		static Database()
		{
			Rows = new Dictionary<Guid, List<Object>>();
		}

		public static void AddRow(Guid id, IEnumerable<Object> row)
		{
			var r = new List<Object>(row);
			r.Insert(0, id);

			Rows[id] = r;
		}

		public static IReader GetByID(Guid id)
		{
			var rows = new List<List<Object>>();

			if (Rows.ContainsKey(id))
			{
				rows.Add(Rows[id]);
			}
			return new ListReader(rows);
		}
	}
}
