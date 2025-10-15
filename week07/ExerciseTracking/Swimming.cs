using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceKilometers = _laps * 50 / 1000.0;
        double distanceMiles = distanceKilometers * 0.62;
        return distanceMiles;
    }

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / GetDistance();

}