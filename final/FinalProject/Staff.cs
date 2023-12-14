

namespace FinalProject
{
    public class Staff : Person
    {
        public int StaffID { get; private set; }
        public string Role { get; set; }
        
        private FileManager fileManager;
        public Staff(string name, int staffID) : base(name)
        {
            StaffID = staffID;
            this.fileManager = new FileManager();
        }

        


        public void CompleteMaintenanceRequest(MaintenanceRequest request, string details)
        {
            if (IsValidRequest(request))
            {
                ResolveRequestDetails(request, details);
                SaveMaintenanceDetails(request, details);
                SaveTenantMaintenanceDetails(request);
                Console.WriteLine($"Maintenance request completed by {Name} for '{request.Issue}'.");
                  fileManager.SaveMaintenanceRequest(request.Requester.Name, details);
            //fileManager.SaveTenantCharges(request.Requester.Name, amount, description);
            }
            else
            {
                Console.WriteLine("Invalid or already resolved maintenance request.");
            }
        }

        private bool IsValidRequest(MaintenanceRequest request)
        {
            return request != null && !request.IsResolved;
        }

        private void ResolveRequestDetails(MaintenanceRequest request, string details)
        {
            request.ResolveRequest(details);
        }

        private void SaveMaintenanceDetails(MaintenanceRequest request, string details)
        {
            string maintenanceDetailsFile = "MaintenanceDetails.txt";
            string content = $"Maintenance Request: {request.Issue}\nDetails: {details}\n\n";

            File.AppendAllText(maintenanceDetailsFile, content);
            Console.WriteLine($"Maintenance details added and saved to {maintenanceDetailsFile}.");
        }

        private void SaveTenantMaintenanceDetails(MaintenanceRequest request)
        {
            if (request.IsResolved && !string.IsNullOrEmpty(request.Details))
            {
                Tenant tenant = request.Requester;
                if (tenant != null)
                {
                    string tenantMaintenanceDetailsFile = $"{tenant.Name}_MaintenanceDetails.txt";
                    string content = $"Maintenance Request: {request.Issue}\nDetails: {request.Details}\n\n";

                    File.AppendAllText(tenantMaintenanceDetailsFile, content);
                    Console.WriteLine($"Maintenance details added and saved to {tenantMaintenanceDetailsFile}.");
                }
            }
        }

         
    }

}
