using RelationalRefactorOriginal.Core;

namespace RelationalRefactorOriginal.Entities
{
	public class Address : Entity
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string Line3 { get; set; }
		public string Town { get; set; }
		public string County { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; }

		protected internal override void Read(IReader reader)
		{
			Line1 = reader.GetString(DbFields.Line1);
			Line2 = reader.GetString(DbFields.Line2);
			Line3 = reader.GetString(DbFields.Line3);
			Town = reader.GetString(DbFields.Town);
			County = reader.GetString(DbFields.County);
			PostCode = reader.GetString(DbFields.PostCode);
			Country = reader.GetString(DbFields.Country);

			base.Read(reader);
		}

		private class DbFields
		{
			public const int Line1 = 1;
			public const int Line2 = 2;
			public const int Line3 = 3;
			public const int Town = 4;
			public const int County = 5;
			public const int PostCode = 6;
			public const int Country = 7;
		}
	}
}
