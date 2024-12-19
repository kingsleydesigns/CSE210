public abstract class Activity
{
    private string _name;
    private DateTime _date;
    private int _minutes;

    protected Activity(string name, DateTime date, int minutes)
    {
        _name = name;
        _date = date;
        _minutes = minutes;
    }

    public string Name => _name;
    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // Distance in miles or kilometers
    public abstract double GetSpeed(); // Speed in mph or kph
    public abstract double GetPace(); // Pace in min per mile or min per km

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {Name} ({Minutes} min): Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace {GetPace():F2} min per mile";
    }
}
