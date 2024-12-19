public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base("Cycling", date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (GetSpeed() * minutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / GetSpeed();
}