using System;

//A swimming activty that stores the number of laps (50 meters)
//and converts it to distance in miles.
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    //Convert lap to distance
    public override double GetDistance()
    {
        double distanceKilometers = _laps * 50 / 1000.0;
        double distanceMiles = distanceKilometers * 0.62;
        return distanceMiles;
    }

    //Speed = distance / hours and Pace = minutes / miles.
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / GetDistance();

}