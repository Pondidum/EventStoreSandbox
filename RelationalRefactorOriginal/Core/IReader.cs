using System;

namespace RelationalRefactorOriginal.Core
{
	public interface IReader
	{
		Boolean Read();

		Guid GetGuid(int index);
		String GetString(int index);
		DateTime GetDateTime(int index);
		T GetEnum<T>(int index);
	}
}
