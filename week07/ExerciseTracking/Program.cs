using System;

public class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 10, 14), 30, 3.0),
            new Cycling(new DateTime(2025, 10, 14), 45, 12.0),
            new Swimming(new DateTime(2025, 10, 14), 25, 20),
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}


