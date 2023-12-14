using System;
using System.IO;

namespace FinalProject
{
    public class Manager : Staff
    {
        private FileManager fileManager;
        public Manager(string name, int staffID) : base(name, staffID)
        {
            fileManager = new FileManager();
        }

        public void RentToNewTenant(Apartment apartment, Tenant tenant)
        {
            if (apartment != null && tenant != null)
            {
                apartment.Rent(tenant);
                Console.WriteLine($"{tenant.Name} added to Apartment {apartment.ApartmentNumber}.");
                SaveTenantInformation(tenant);
            }
            else
            {
                Console.WriteLine("Invalid apartment or tenant.");
            }
        }

        public void EvictTenant(Apartment apartment)
        {
            if (apartment != null && apartment.IsOccupied)
            {
                apartment.Vacate();
                Console.WriteLine($"Tenant evicted from Apartment {apartment.ApartmentNumber}.");
            }
            else
            {
                Console.WriteLine("Apartment is vacant or invalid.");
            }
        }

        public void AddChargesToTenant(Tenant tenant, decimal amount, string description)
        {
            if (tenant != null)
            {
                tenant.AddCharges(amount, description);
                Console.WriteLine($"Charges added to {tenant.Name}'s account: {description} - ${amount}");
                fileManager.SaveTenantCharges(tenant.Name, amount, description);
            }
            else
            {
                Console.WriteLine("Invalid tenant.");
            }
        }

        internal static void SaveTenantInformation(Tenant tenant)
        {
            if (tenant != null)
            {
                string fileName = $"{tenant.Name}_Info.txt"; // File name based on tenant's name
                string content = $"{DateTime.Now}: Tenant Information\n";
                
                content += $"Tenant Name: {tenant.Name}\n"; // If the tenant has a 'Name' property
                content += $"Apartment Number: {tenant.ApartmentNumber}\n";
                content += $"Charges:\n";

                foreach (var charge in tenant.Charges)
                {
                    content += $"{charge.PurposeDescription}: ${charge.Amount}\n";
                }

                content += "\n";

                File.WriteAllText(fileName, content);
                Console.WriteLine($"Tenant information saved to {fileName}.");
            }
            else
            {
                Console.WriteLine("Invalid tenant.");
            }
        }
    }
}
