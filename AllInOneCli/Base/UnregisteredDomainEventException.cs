using System;

namespace AllInOneCli.Base
{
	public class UnregisteredDomainEventException : Exception
	{
		public UnregisteredDomainEventException(String eventName, String entityName)
			: base(String.Format("The requested Domain Event '{0}' is not registered in '{1}'.", eventName, entityName))
		{
		}
	}
}
