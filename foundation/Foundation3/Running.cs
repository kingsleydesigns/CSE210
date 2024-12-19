public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base("Running", date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (GetDistance() / minutes) * 60;
    public override double GetPace() => minutes / GetDistance();
}