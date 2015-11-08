using System.Collections.Generic;

public static class Utility
{
	public static string ListToString<T>(List<T> list)
	{
		var str = "";
		list.ForEach(item => str += item.ToString() + ",");

		return str;
	}
}

