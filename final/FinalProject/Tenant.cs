namespace FinalProject;
        public class Tenant : Person
    {
        private FileManager fileManager;
        public int ApartmentNumber { get; protected set; }
        public List<FinancialTransaction> Charges { get; private set; }
        private List<MaintenanceRequest> maintenanceRequests;
         private string apartmentDataFile = "ApartmentData.txt";

        public Tenant(string name) : base(name)
        {
            maintenanceRequests = new List<MaintenanceRequest>();
            Charges = new List<FinancialTransaction>(); // Initialize Charges list
            this.fileManager = new FileManager();
        }

         public List<MaintenanceRequest> GetMaintenanceRequests()
        {
            return maintenanceRequests;
        }

       public void SubmitMaintenanceRequest(string apartmentNumber, string issue)
{
    Apartment apartment = new(apartmentNumber);
    if (apartment != null)
    {
        MaintenanceRequest request = new MaintenanceRequest(issue, this);
        apartment.AddMaintenanceRequest(request);
        maintenanceRequests.Add(request);
        fileManager.SaveMaintenanceRequest(Name, issue); // Save the request to the tenant's file
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
        Console.WriteLine($"Apartment Number: {ApartmentNumber}");
        Console.WriteLine($"Tenant: {Name}");
        
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
                fileManager.SaveTenantCharges(Name, amount, description);

                Console.WriteLine($"Charges added for '{description}' - ${amount}");
            }
            else
            {
                Console.WriteLine("Invalid charge amount.");
            }
        }

        
    }
        
