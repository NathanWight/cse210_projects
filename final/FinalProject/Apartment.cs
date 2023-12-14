using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class Apartment
    {
        public string ApartmentNumber { get; } // Apartment number should be set via constructor
        
        public bool IsOccupied { get; private set; }
        public Tenant CurrentTenant { get; private set; }
        public object Tenants { get; internal set; }


        private List<MaintenanceRequest> maintenanceRequests;
        
        public static implicit operator Apartment(int v)
{
    string apartmentNumber = v.ToString(); // Convert integer to string to set as the apartment number
    return new Apartment(apartmentNumber);
}

        public Apartment(string apartmentNumber)
        {
            ApartmentNumber = apartmentNumber;
            IsOccupied = false;
            CurrentTenant = null;
            maintenanceRequests = new List<MaintenanceRequest>();
        }

        public void Rent(Tenant tenant)
        {
            if (!IsOccupied)
            {
                IsOccupied = true;
                CurrentTenant = tenant;
                Console.WriteLine($"Apartment {ApartmentNumber} has been rented to {tenant.Name}.");
            }
            else
            {
                Console.WriteLine($"Apartment {ApartmentNumber} is already occupied.");
            }
        }

        public void Vacate()
        {
            if (IsOccupied)
            {
                IsOccupied = false;
                Console.WriteLine($"Apartment {ApartmentNumber} has been vacated.");
            }
            else
            {
                Console.WriteLine($"Apartment {ApartmentNumber} is already vacant.");
            }
        }

        public void AddMaintenanceRequest(MaintenanceRequest request)
        {
            maintenanceRequests.Add(request);
            Console.WriteLine($"Maintenance request added for Apartment {ApartmentNumber}: {request.Issue}");
        }

        public List<MaintenanceRequest> GetMaintenanceRequests()
        {
            return maintenanceRequests;
        }

        

    }
}
