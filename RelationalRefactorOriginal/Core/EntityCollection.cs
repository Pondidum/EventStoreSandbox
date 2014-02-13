using System;
using System.Collections.Generic;

namespace RelationalRefactorOriginal.Core
{
	public class EntityCollection<T> : List<T> where T : Entity, new()
	{
		public Guid OwnerID { get; set; }

		public void Load()
		{
			//some loading
			var reader = (IReader)new Object();

			Clear();

			while (reader.Read())
			{
				var entity = new T();
				entity.Read(reader);

				Add(entity);
			}
		}
	}
}