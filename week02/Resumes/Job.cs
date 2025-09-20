using System;

public class Job
{
    // Member variables
    public string _JobTitle;
    public string _Company;
    public int _startYear;
    public int _endYear;

    // Method to display job details
    public void Display()
    {
        Console.WriteLine($"{_JobTitle} ({_Company}) {_startYear} - {_endYear}");
    }
}