using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class MaintenanceRequest
    {
        protected List<MaintenanceRequest> maintenanceRequests;
        private FinalProject.Tenant tenant; // Specify the namespace for the Tenant class

        public MaintenanceRequest(string issue, Tenant tenant)
        {
            Issue = issue;
            this.tenant = tenant;
        }

        public MaintenanceRequest()
        {
            
        }


        public object Issue { get; private set; }
        public bool IsResolved { get; internal set; }
        public string Details { get; internal set; }
        public FinalProject.Tenant Requester { get; internal set; }

        public void Maintenance()
        {
            maintenanceRequests = new List<MaintenanceRequest>();
        }

        public void AddMaintenanceRequest(MaintenanceRequest request)
        {
            maintenanceRequests.Add(request);
            Console.WriteLine($"Maintenance request added: {request.Issue}");
        }

        internal void ResolveRequest(string details)
        {
            IsResolved = true;
            Details = details;
        }
    }
}
