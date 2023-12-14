using System;

namespace FinalProject
{
    public class TenantManagementSystem
    {
        private UserManagement userManagement;

        public TenantManagementSystem()
        {
            userManagement = new UserManagement();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Tenant Management System!");
            Console.WriteLine("1. Login\n2. Create Account\n3. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        CreateAccount();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
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

        private void Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (userManagement.AuthenticateTenant(username, password))
            {
                Console.WriteLine("Login successful!");
                ShowTenantMenu(username);
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
                Start();
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (userManagement.AddTenant(username, password))
            {
                Console.WriteLine("Account created successfully!");
                Login();
            }
            else
            {
                Console.WriteLine("Username already exists. Please choose another.");
                CreateAccount();
            }
        }

        private void ShowTenantMenu(string username)
        {
            Tenant tenant = new Tenant(username); // Assuming a tenant instance is created

            while (true)
            {
                Console.WriteLine($"Welcome, {username}!");
                Console.WriteLine("1. View Maintenance Requests");
                Console.WriteLine("2. Submit Maintenance Request");
                Console.WriteLine("3. View Apartment Details");
                Console.WriteLine("4. Add Charges");
                Console.WriteLine("5. Logout");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Maintenance requests for {tenant.Name}:");
                            int count = 0;
                            foreach (MaintenanceRequest request in tenant.GetMaintenanceRequests())
                            {
                                Console.WriteLine($"{count++}. {request.Issue} - Status: {(request.IsResolved ? "Resolved" : "Pending")}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the issue description:");
                            string issue = Console.ReadLine();
                            Console.WriteLine("Enter the apartment number:");
                            string apartmentNumber = Console.ReadLine();
                            if (true)

                            {
                                tenant.SubmitMaintenanceRequest(apartmentNumber, issue);
                                Console.WriteLine("Maintenance request submitted successfully!");
                            }
                            
                            break;
                        case 3:
                            Console.WriteLine($"Apartment Number: {tenant.ApartmentNumber}");
                            Console.WriteLine($"Tenant: {tenant.Name}");
                            break;
                        case 4:
                            Console.WriteLine("Enter amount:");
                            decimal amount;
                            if (decimal.TryParse(Console.ReadLine(), out amount))
                            {
                                Console.WriteLine("Enter description:");
                                string description = Console.ReadLine();
                                tenant.AddCharges(amount, description);
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Logging out...");
                            return;
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