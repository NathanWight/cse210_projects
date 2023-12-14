namespace FinalProject
{
    class Menu
    {
    

        private Manager manager;
        private Staff staff;
        private ApartmentManager ApartmentManager;

        public Menu()
        {


        }

        public void StartMenu()
        {
        
            bool isLoggedIn = true; 

            while (isLoggedIn)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add Tenant to Apartment");
                Console.WriteLine("2. Evict Tenant from Apartment");
                Console.WriteLine("3. Add Charges to Tenant");
                Console.WriteLine("4. Save Tenant Information to File");
                Console.WriteLine("5. Complete Maintenance Request");
                Console.WriteLine("6. Sign out");
                Console.WriteLine("Enter your choice (1-6):");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter tenant name:");
                            string tenantName = Console.ReadLine();
                            Console.WriteLine("Enter tenant apartment number:");
                            string apartmentNumber = Console.ReadLine();
                            Apartment apartmentToAddTenant = ApartmentManager.GetApartmentByNumber(apartmentNumber);
                            if (apartmentToAddTenant != null)
                            {
                                // Create a Tenant object and pass it to RentToNewTenant method
                                Tenant newTenant = new Tenant(tenantName); 
                                manager.RentToNewTenant(apartmentToAddTenant, newTenant);
                            }
                            else
                            {
                                Console.WriteLine("Apartment not found.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter tenant apartment number:");
                            string evictionApartmentNumber = Console.ReadLine();
                            Apartment apartmentToEvict = ApartmentManager.GetApartmentByNumber(evictionApartmentNumber);
                            manager.EvictTenant(apartmentToEvict); // Manager's functionality
                            break;

                        case 3:
                            Console.WriteLine("Enter tenant apartment number:");
                            string apartmentNumberForCharges = Console.ReadLine();
                            Apartment apartmentForCharges = ApartmentManager.GetApartmentByNumber(apartmentNumberForCharges);
                            if (apartmentForCharges != null && apartmentForCharges.CurrentTenant != null)
                            {
                                Console.WriteLine("Enter charge amount:");
                                decimal chargeAmount = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter charge description:");
                                string chargeDescription = Console.ReadLine();
                                manager.AddChargesToTenant(apartmentForCharges.CurrentTenant, chargeAmount, chargeDescription);
                            }
                            else
                            {
                                Console.WriteLine("Apartment not found or no tenant in the apartment.");
                            }
                            break;


                        case 4:
                            Console.WriteLine("Enter tenant apartment number:");
                            string saveApartmentNumber = Console.ReadLine();
                            Apartment apartmentToSaveInfo = ApartmentManager.GetApartmentByNumber(saveApartmentNumber);
                            if (apartmentToSaveInfo != null && apartmentToSaveInfo.CurrentTenant != null)
                            {
                                Manager.SaveTenantInformation(apartmentToSaveInfo.CurrentTenant);
                            }
                            else
                            {
                                Console.WriteLine("No tenant found in the specified apartment.");
                            }
                            break;


                        case 5:
                            Console.WriteLine("Enter maintenance request details:");
                            string maintenanceDetails = Console.ReadLine();
                            MaintenanceRequest request = new(); // Create or retrieve the MaintenanceRequest object
                            staff.CompleteMaintenanceRequest(request, maintenanceDetails);
                            break;

                        case 6:
                            isLoggedIn = false;
                            Console.WriteLine("Signed out.");
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
