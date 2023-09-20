using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
int number = randomGenerator.Next(1, 11);
bool test = false;
while (test == false)
{
    Console.WriteLine("guess the magic number:");
    int guess = int.Parse(Console.ReadLine());
    if (guess == number)
    {
        Console.WriteLine("Correct");
        test = true;
    }
    if (guess > number)
    {
        Console.WriteLine("Lower");
    }
    if (guess < number)
    {
        Console.WriteLine("Larger");
    }
    
}

    }
}