public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    
    public virtual int GetPoints()
    {
        return _points; 
    }

    public virtual bool IsComplete()
    {
        
        return false; 
    }

    public virtual void RecordEvent()
    {
        
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName}: {_description}";
    }
}
