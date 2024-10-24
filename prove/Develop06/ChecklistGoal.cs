public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override int GetPoints()
    {
        if (IsComplete())
        {
            return _points + _bonus; 
        }
        return _points; 
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Completed {_amountCompleted}/{_target} times)";
    }
}
