using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate() => _date;
    public double GetMinutes() => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"\n{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
        $"Distance: {GetDistance():0.0} miles, " + $"Speed: {GetSpeed():0.0} mph, " + 
        $"Pace: {GetPace():0.00} min per mile";
    }
}