using System;

//A cycling activity that stores the average speed. It calculates the distance and pace.
public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed; 
    public override double GetDistance() => (_speed / GetMinutes()) * 60; // Distance (converted to hours) = speed * time. 
    public override double GetPace() => 60 / _speed; // Pace = 60 / speed.
}