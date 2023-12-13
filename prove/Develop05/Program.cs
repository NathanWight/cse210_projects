class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        Console.WriteLine("Enter your username: ");
        User player = new User(Console.ReadLine());

        do
        {
            Console.WriteLine($"Total Score: {player.GetTotalPoints()}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Establish New Objective");
            Console.WriteLine("2. List Objectives");
            Console.WriteLine("3. Save Objectives");
            Console.WriteLine("4. Load Objectives");
            Console.WriteLine("5. Record Achievement");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            int userChoice;
            bool isValidInput = int.TryParse(Console.ReadLine(), out userChoice);

            if (isValidInput)
            {
                switch (userChoice)
                {
                    case 1:
                        player.CreateNewGoal();
                        break;

                    case 2:
                        player.DisplayGoals();
                        break;

                    case 3:
                        player.Save();
                        break;

                    case 4:
                        player.Load();
                        break;

                    case 5:
                        player.RecordEvent();
                        break;

                    case 6:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadLine(); // Wait for user to press Enter before continuing
            }
        } while (isRunning);
    }
}
