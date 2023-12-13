
namespace FinalProject;



public class Apartment
{
    public string ApartmentNumber { get; }
    public bool IsOccupied { get; private set; }
    public Tenant CurrentTenant { get; private set; }
    private List<MaintenanceRequest> maintenanceRequests;

    public Apartment(string v)
    {
        ApartmentNumber = ApartmentNumber;
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

    internal object GetMaintenanceRequests()
    {
       return maintenanceRequests;
    }

}
