using System;

class Program
{
    static void Main(string[] args)
    {
        // First Job
        Job job1 = new Job();
        job1._JobTitle = "IT Administrative Assistant";
        job1._Company = "Bahamas Technical & Vocational Institute";
        job1._startYear = 2018;
        job1._endYear = 2022;

        // Second Job
        Job job2 = new Job();
        job2._JobTitle = "Jr Network Administrator";
        job2._Company = "Bahamas Technical & Vocational Institute";
        job2._startYear = 2022;
        job2._endYear = 2027;

        // Resume
        Resume myResume = new Resume();
        myResume._name = "Sandra Cooper";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display Resume
        myResume.Display();
    }
}