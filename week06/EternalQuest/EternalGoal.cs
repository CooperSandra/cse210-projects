using System;

//Eternal goal, meaning never finishes, points always awarded. 
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    : base(name, description, points) { }

    public override void RecordEvent()
    {
        //Note: Nothing to change for completion - Its eternal.
    }

    public override bool IsComplete() => false;

    public override string GetDetailsRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }

}