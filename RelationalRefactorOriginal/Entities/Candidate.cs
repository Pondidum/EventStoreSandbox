using System;
using RelationalRefactorOriginal.Core;

namespace RelationalRefactorOriginal.Entities
{
	public class Candidate : Entity
	{
		public String Name { get; set; }
		public Sexes Sex { get; set; }
		public DateTime DateOfBirth { get; set; }

		public AddressCollection Addresses
		{
			get
			{
				return _addresses.Value;
			}
		}

		private readonly Lazy<AddressCollection> _addresses;

		public Candidate()
		{
			_addresses = new Lazy<AddressCollection>(() => new AddressCollection(this));
		}

		protected internal override void Read(IReader reader)
		{
			Name = reader.GetString(DbFields.Name);
			Sex = reader.GetEnum<Sexes>(DbFields.Sex);
			DateOfBirth = reader.GetDateTime(DbFields.DoB);

			base.Read(reader);
		}

		private class DbFields
		{
			public const int Name = 1;
			public const int Sex = 2;
			public const int DoB = 3;
		}
	}
}
