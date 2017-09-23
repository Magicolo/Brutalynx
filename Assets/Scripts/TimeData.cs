using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeData
{
    int hours;
    int minutes;

    public static TimeData operator -(TimeData a, TimeData b)
    {
        TimeData t = new TimeData();

        t.hours = a.hours - b.hours;
        t.minutes = a.minutes - b.minutes;

        if(t.minutes < 0)
        {
            t.minutes = 60 - t.minutes;
            t.hours--;
        }

        return t;
    }

    public int ToMinutes()
    {
        return hours * 60 + minutes;
    }
}
