using System;

//Checklist goal has to be completed (a target) number of times. 
public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, int points, int target, int bonus, int completed = 0)
    : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = completed;
    }

    public override void RecordEvent() //Increments the count and marks when target is completed.
    {
        if (_amountCompleted < _target)
            _amountCompleted++;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public int Target => _target;
    public int Bonus => _bonus;
    public int AmountCompleted => _amountCompleted;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[]";
        return $"{status} {Name}: {Description} (-- Completed {_amountCompleted}/{_target})";
    }

    public override string GetDetailsRepresentation()
    {
        return $"CheckListGoal|{Name}|{Description}|{Points}|{Target}|{Bonus}|{AmountCompleted}";
    }

}