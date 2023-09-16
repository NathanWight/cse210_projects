using System;

class Program
{
    static void Main(string[] args)
    { int percent = 200;

        Console.WriteLine("What was the grade percent?");
       
        percent = int.Parse (Console.ReadLine ());
       string grade = "invalid";
        
        if (percent >=90)
        { 
            grade = "A";
        }
        else if (percent >= 80)
        {
            grade = "B";
        }
        else if (percent >= 70)
        {
            grade = "C";
        }
        else if (percent >= 60)
        {
            grade = "D";
        }
        else{
            grade = "F";
        }
        Console.WriteLine(grade);
    }
}