using System;

public abstract class Activity
{
    private DateTime _date;
    private int _duration;

    protected Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public int Duration => _duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_duration} min): Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
