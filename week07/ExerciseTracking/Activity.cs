using System;
using System.Collections.Generic;

//The base class for all activities, that stores the date and duration.
//Defines abstract methods for calculating the distance, speed, and pace.
public abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    //Constructor to set the date and duration.
    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    //Getter methods
    public DateTime GetDate() => _date;
    public double GetMinutes() => _minutes;

    //Abstract methods that is executed in each derived class
    public abstract double GetDistance(); //In Miles
    public abstract double GetSpeed(); //Miles Per Hour
    public abstract double GetPace(); //Minutes Per Mile

    //Method shared by all activities to return a formatted summary
    public virtual string GetSummary()
    {   //A summary in the form of: 
        // 14 Oct 2025 Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
        $"Distance: {GetDistance():0.0} miles, " + $"Speed: {GetSpeed():0.0} mph, " +
        $"Pace: {GetPace():0.00} min per mile";
    }
}