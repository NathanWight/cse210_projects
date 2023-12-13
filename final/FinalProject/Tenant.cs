
namespace FinalProject;

public class Tenant : Person
{
    public string ApartmentNumber { get; private set; }
    
    public List<FinancialTransaction> Charges { get; private set; }



    private List<MaintenanceRequest> maintenanceRequests;
    

    public Tenant(string name) : base(name)
    {
        maintenanceRequests = new List<MaintenanceRequest>();
       
    }

    public void SubmitMaintenanceRequest(Apartment apartment, string issue)
    {
        if (apartment != null)
        {
            MaintenanceRequest request = new MaintenanceRequest(issue, this);
            apartment.AddMaintenanceRequest(request);
            maintenanceRequests.Add(request);
        }
        else
        {
            Console.WriteLine("Invalid apartment.");
        }
    }

    public void ViewMaintenanceRequests()
    {
        Console.WriteLine($"Maintenance requests for {Name}:");
        int count = 0;
        foreach (MaintenanceRequest request in maintenanceRequests)
        {
            Console.WriteLine($"{count++}. {request.Issue} - Status: {(request.IsResolved ? "Resolved" : "Pending")}");
        }
    }

    public void ViewApartmentDetails()
    {
        Console.WriteLine($"Tenant: {Name}");
        Console.WriteLine($"Apartment Number: {ApartmentNumber}");
    }
    public void AddCharges(decimal amount, string description)
        {
            if (amount > 0)
            {
                Charges.Add(new FinancialTransaction
                {
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    Status = "Unpaid", // Initial status can be set
                    TransactionId = Guid.NewGuid().ToString(),
                    AccountInformation = $"Charges for {description}",
                    MethodOfPayment = "N/A", // Method of payment can be set later
                    ReceiptConfirmation = "N/A", // Confirmation can be set later
                    PurposeDescription = description
                });

                Console.WriteLine($"Charges added for '{description}' - ${amount}");
            }
            else
            {
                Console.WriteLine("Invalid charge amount.");
            }
        }
        }
    


