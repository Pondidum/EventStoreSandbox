using System;
using System.Collections.Generic;

namespace RelationalRefactorOriginal.Core
{
	public class ListReader : IReader
	{
		private int _row;
		private readonly List<List<Object>> _list;

		public ListReader(List<List<Object>> list)
		{
			_list = list;
			_row = -1;
		}

		private void Check()
		{
			if (_row < 0 || _row >= _list.Count)
				throw new IndexOutOfRangeException();
		}

		public bool Read()
		{
			return (_row++ < _list.Count);
		}

		public Guid GetGuid(int index)
		{
			Check();
			return (Guid)_list[_row][index];
		}

		public string GetString(int index)
		{
			Check();
			return (String)_list[_row][index];
		}

		public DateTime GetDateTime(int index)
		{
			Check();
			return (DateTime)_list[_row][index];
		}

		public T GetEnum<T>(int index)
		{
			Check();
			return (T)_list[_row][index];
		}
	}
}