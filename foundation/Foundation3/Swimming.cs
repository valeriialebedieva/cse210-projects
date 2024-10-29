using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthKm = 50 / 1000.0;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthKm;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / GetDistance();
    }
}
