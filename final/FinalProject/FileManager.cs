using System;
using System.IO;

namespace FinalProject
{
    public class FileManager
    {
          private string maintenanceRequestDirectory;
        private string tenantChargesDirectory;

        public FileManager()
        {
            this.maintenanceRequestDirectory = "MaintenanceRequests";
            this.tenantChargesDirectory = "TenantCharges";
            Directory.CreateDirectory(maintenanceRequestDirectory);
            Directory.CreateDirectory(tenantChargesDirectory);
        }

        public void SaveMaintenanceRequest(string tenantName, string issue)
        {
            string maintenanceRequestFile = $"{maintenanceRequestDirectory}/{tenantName}_MaintenanceRequests.txt";
            string content = $"{DateTime.Now}: Issue - '{issue}', Status: Pending\n";

            File.AppendAllText(maintenanceRequestFile, content);
            Console.WriteLine($"Maintenance request saved to {maintenanceRequestFile}.");
        }


        public void SaveTenantCharges(string tenantName, decimal amount, string description)
        {
            string chargesFile = $"{tenantChargesDirectory}/{tenantName}_Charges.txt";
            string content = $"{DateTime.Now}: Charges for '{description}' - ${amount}\n";

            File.AppendAllText(chargesFile, content);
            Console.WriteLine($"Tenant charges saved to {chargesFile}.");
        }
    }
}
