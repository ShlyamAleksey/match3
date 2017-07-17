using System;
using System.Collections.Generic;
using System.Reflection;
namespace Lizzard
{
	public class ListUtils
	{
		public ListUtils()
		{
		}

		static public List<T> cloneList<T>(List<T> list) where T : class
		{
			List<T> copy = new List<T>();

			foreach (T item in list)
			{
				copy.Add(item);
			}

			return copy;
		}
	}
}
