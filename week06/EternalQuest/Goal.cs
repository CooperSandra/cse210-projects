using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    private string _shortName; //The goal name.
    private string _description; //Description of the goal.
    private int _points; //Points for (completing/recording) the goal.

    public string Name => _shortName;
    public string Description => _description;
    public int Points => _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(); //Call when user record progress on the goal and return points earned.
    public abstract bool IsComplete(); //Returns true once the goal is completed.
    public virtual string GetDetailsString() //Default details string. 
    {
        string status = IsComplete() ? "[X]" : "[]";
        return $"{status} {_shortName} ({_description})";
    } 
    public abstract string GetDetailsRepresentation(); //Return a line that can be saved to a text file
}