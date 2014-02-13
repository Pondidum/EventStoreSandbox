using System;

namespace RelationalRefactorOriginal.Core
{
	public class Entity
	{
		public Guid ID { get; set; }

		public void Save()
		{
			
		}

		public void Load()
		{
			var reader = Database.GetByID(ID);

			if (reader.Read())
			{
				Read(reader);
			}
		}

		protected internal virtual void Read(IReader reader)
		{
			ID = reader.GetGuid(0);
		}

	}
}
