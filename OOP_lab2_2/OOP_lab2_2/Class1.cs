using System;

public class MyTime
{
    private int hour;
    private int minute;
    private int second;

    public MyTime(int h, int m, int s)
    {
        if (h < 0 || h > 23)
            throw new ArgumentOutOfRangeException("hour", "Hour must be between 0 and 23");
        if (m < 0 || m > 59)
            throw new ArgumentOutOfRangeException("minute", "Minute must be between 0 and 59");
        if (s < 0 || s > 59)
            throw new ArgumentOutOfRangeException("second", "Second must be between 0 and 59");

        hour = h;
        minute = m;
        second = s;
    }

    public override string ToString()
    {
        return $"{hour}:{minute:D2}:{second:D2}";
    }

    public int TimeSinceMidnight()
    {
        return hour * 3600 + minute * 60 + second;
    }

    public static MyTime TimeSinceMidnight(int t)
    {
        int secPerDay = 86400;
        t %= secPerDay;
        if (t < 0)
            t += secPerDay;
        int h = t / 3600;
        int m = (t / 60) % 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }

    public void AddOneSecond()
    {
        AddSeconds(1);
    }

    public void AddOneMinute()
    {
        AddSeconds(60);
    }

    public void AddOneHour()
    {
        AddSeconds(3600);
    }

    public void AddSeconds(int s)
    {
        int totalSeconds = TimeSinceMidnight() + s;
        MyTime newTime = TimeSinceMidnight(totalSeconds);
        this.hour = newTime.hour;
        this.minute = newTime.minute;
        this.second = newTime.second;
    }

    public static int Difference(MyTime mt1, MyTime mt2)
    {
        return mt1.TimeSinceMidnight() - mt2.TimeSinceMidnight();
    }

    public string WhatLesson()
    {
        int seconds = TimeSinceMidnight();

        if (seconds < 8 * 3600) return "Пари ще не почалися";
        if (seconds < 9 * 3600 + 20 * 60) return "1-а пара";
        if (seconds < 9 * 3600 + 30 * 60) return "Перерва між 1-ю та 2-ю парами";
        if (seconds < 10 * 3600 + 50 * 60) return "2-а пара";
        if (seconds < 11 * 3600 + 00 * 60) return "Перерва між 2-ю та 3-ю парами";
        if (seconds < 12 * 3600 + 20 * 60) return "3-я пара";
        if (seconds < 12 * 3600 + 30 * 60) return "Перерва між 3-ю та 4-ю парами";
        if (seconds < 13 * 3600 + 50 * 60) return "4-а пара";
        if (seconds < 14 * 3600 + 00 * 60) return "Перерва між 4-ю та 5-ю парами";
        if (seconds < 15 * 3600 + 20 * 60) return "5-а пара";
        if (seconds < 15 * 3600 + 30 * 60) return "Перерва між 5-ю та 6-ю парами";
        if (seconds < 16 * 3600 + 50 * 60) return "6-а пара";

        return "Пари вже скінчилися";
    }
}

