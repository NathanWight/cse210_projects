namespace FinalProject
{
    using System;

namespace FinalProject
{
    class Menue
    {
        static void ManagerLogin(string[] args)
        {
            // Prompting the user to create a username and password for the manager
            Console.WriteLine("Create a username for the manager:");
            string username = Console.ReadLine();

            Console.WriteLine("Create a password for the manager:");
            string password = Console.ReadLine();

            // Creating a manager with the provided username and password
            Manager manager = new Manager(username, password.GetHashCode()); // Using password hash for simplicity

            // Manager authentication
            Console.WriteLine("\nLogin as Manager:");
            Console.WriteLine("Enter username:");
            string inputUsername = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string inputPassword = Console.ReadLine();

          bool isManagerLoggedIn = true; // For demonstration purposes, assuming manager is already logged in

            while (isManagerLoggedIn)
            {
                // Manager options
                Console.WriteLine("\nManager Options:");
                Console.WriteLine("1. Add Tenant to Apartment");
                Console.WriteLine("2. Evict Tenant from Apartment");
                Console.WriteLine("3. Add Charges to Tenant");
                Console.WriteLine("4. Save Tenant Information to File");
                Console.WriteLine("5. Sign out");
                Console.WriteLine("Enter your choice (1-5):");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Add tenant to an apartment
                            Console.WriteLine("Enter tenant name:");
                            string tenantName = Console.ReadLine();
                            Console.WriteLine("Enter tenant Apartment number:");
                            string apartmentNumber = Console.ReadLine();
                            // Add logic to create tenant and add to apartment
                            break;

                        case 2:
                            // Evict a tenant from an apartment
                            Console.WriteLine("Enter tenant Apartment number:");
                            string evictionApartmentNumber = Console.ReadLine();
                            // Add logic to evict tenant from apartment
                            break;

                        case 3:
                            // Add charges to a tenant's account
                            Console.WriteLine("Enter tenant name:");
                            string tenantNameForCharges = Console.ReadLine();
                            Console.WriteLine("Enter charge amount:");
                            decimal chargeAmount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter charge description:");
                            string chargeDescription = Console.ReadLine();
                            // Add logic to add charges to tenant's account
                            break;

                        case 4:
                            // Save tenant information to file
                            Console.WriteLine("Enter tenant Apartment number:");
                            string saveApartmentNumber = Console.ReadLine();
                            // Add logic to save tenant information to file
                            break;

                        case 5:
                            // Sign out
                            isManagerLoggedIn = false;
                            Console.WriteLine("Manager signed out.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}

}