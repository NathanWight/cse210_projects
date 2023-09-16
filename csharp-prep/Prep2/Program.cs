using System;

class Program
{
    static void Main(string[] args)
    { int percent = 200;
    

        Console.WriteLine("What was the grade percent?");
       
        percent = int.Parse (Console.ReadLine ());
       string grade = "invalid";
       int level = percent;
string levelAsString = level.ToString();
char lastDigitChar = levelAsString[levelAsString.Length - 1]; // Get the last character
int lastDigit = int.Parse(lastDigitChar.ToString()); // Convert the last character back to an integer
string gradeLevel = (lastDigit >= 7) ? "+" : "-";
if (lastDigit<7 && lastDigit> 3)
{
    gradeLevel = null;
}
        
        if (percent >=90)
        { 
            if (percent>=95)
            {
                gradeLevel = null;
            }
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
        Console.WriteLine(grade + gradeLevel);
    }
}