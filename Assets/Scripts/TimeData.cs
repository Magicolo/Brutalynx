using System;

[Serializable]
public class TimeData
{
    public int Hours = 0;
    public int Minutes = 0;

    public static TimeData operator -(TimeData a, TimeData b)
    {
        TimeData t = new TimeData();

        t.Hours = a.Hours - b.Hours;
        t.Minutes = a.Minutes - b.Minutes;

        if(t.Minutes < 0)
        {
            t.Minutes = 60 + t.Minutes;
            t.Hours--;
        }

        return t;
    }

    public int ToMinutes()
    {
        return Hours * 60 + Minutes;
    }

    public override string ToString()
    {
        return string.Format("{0}:{1}", Hours, Minutes);
    }
}
