using System;

namespace FinalProject
{
    public class Manager : Staff
    {
        public Manager(string name, int staffID) : base(name, staffID)
        {
        }

        public void AddTenantToApartment(Apartment apartment, Tenant tenant)
        {
            if (apartment != null && tenant != null)
            {
                apartment.Rent(tenant);
                Console.WriteLine($"{tenant.Name} added to Apartment {apartment.ApartmentNumber}.");
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

         public void SaveTenantsToFile(Apartment apartment)
        {
            if (apartment != null && apartment.IsOccupied)
            {
                string fileName = $"{apartment.ApartmentNumber}_Tenants.txt";
                string content = $"{DateTime.Now}: {apartment.CurrentTenant.Name}";

                // Append charges information if available
                if (apartment.CurrentTenant.Charges.Count > 0)
                {
                    content += " - Charges: ";
                    foreach (var charge in apartment.CurrentTenant.Charges)
                    {
                        content += $"[{charge.PurposeDescription}: ${charge.Amount}] ";
                    }
                }

                content += "\n";

                File.AppendAllText(fileName, content);
                Console.WriteLine($"Tenant information saved to {fileName}.");
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
            }
            else
            {
                Console.WriteLine("Invalid tenant.");
            }
        }
}

}