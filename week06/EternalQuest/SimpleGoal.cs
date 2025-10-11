using System;

//Simple goal is completed once
public class SimpleGoal : Goal
{
    private bool _isComplete; //Tracks if simple goal is completed. 

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    //Marks the goal completed
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsRepresentation()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }

}