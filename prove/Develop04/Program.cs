
class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select an activity: ");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    breathingActivity.RunBreathingActivity();
                    break;
                case 2:
                    listingActivity.RunListingActivity();
                    break;
                case 3:
                    reflectingActivity.RunReflectingActivity();
                    break;
                case 4:
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose a valid activity.");
                    break;
            }
        }
    }
}
