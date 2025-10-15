using System;


//A running activity that stores the distance and use it to calculate the speed and pace.
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance; //Return the distance
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60; //Speed = distance / time (in hours)
    public override double GetPace() => GetMinutes() / GetDistance(); //Pace = time in minutes / distance
}