using RelationalRefactorOriginal.Core;

namespace RelationalRefactorOriginal.Entities
{
	public class AddressCollection : EntityCollection<Address>
	{
		public AddressCollection(Entity owner)
		{
			OwnerID = owner.ID;
			Load();
		}
	}
}
