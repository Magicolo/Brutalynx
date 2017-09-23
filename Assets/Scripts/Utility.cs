using System;

public static class Utility
{
	public static TimeSpan Min(TimeSpan a, TimeSpan b)
	{
		if (a <= b) return a;
		else return b;
	}

	public static TimeSpan Max(TimeSpan a, TimeSpan b)
	{
		if (a >= b) return a;
		else return b;
	}
}
