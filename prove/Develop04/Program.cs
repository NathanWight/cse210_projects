using System;

class Program
{
    static void Main(string[] args)
    {   
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("Please select one of the following activities: ");
            Console.WriteLine();
            Console.WriteLine("1. Reflection Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Breathing Activity");
            Console.WriteLine("4. Quit");
            int selection = int.Parse(Console.ReadLine());

            if (selection == 1){
                ReflectionActivity ReflectionActivity = new ReflectionActivity(10,"This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Reflection", 3,3, "You have completed the Reflection Activity" );
                ReflectionActivity.StartReflectionActivity();
                
            }
            else if (selection == 2){
                ListingActivity ListingActivity = new ListingActivity(10, "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Listing", 3,3, "Great job! You have completed the listing activity.");
                ListingActivity.StartListingActivity();
            }
            else if (selection == 3){
                BreathingActivity breathingActivity = new BreathingActivity(10,"This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", "Breathing", 3, 3, "Great job! You have completed the breathing activity.", 5, 5);
                breathingActivity.StartBreathingActivity();
            }
            else{
                Console.Clear();
                Console.WriteLine("You should be more mindful and spend more time on this program. I am dissapointed.");
                Activity activity = new Activity(10, "", "", 3,3, "");
                activity.InitialPause();
                break;
            }
        }
        

        



        
        
    }
}