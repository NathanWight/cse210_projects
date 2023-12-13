using System;
using System.Collections.Generic;
namespace FinalProject;

public class MaintenanceRequest
{
    protected List<MaintenanceRequest> maintenanceRequests;
    private Tenant tenant;

    public MaintenanceRequest(string issue, Tenant tenant)
    {
        Issue = issue;
        this.tenant = tenant;
    }


    public object Issue { get; private set; }
    public bool IsResolved { get; internal set; }
    public string Details { get; internal set; }
    public Tenant Requester { get; internal set; }

    public void Maintenance()
    {
        maintenanceRequests = new List<MaintenanceRequest>();
    }

    public void AddMaintenanceRequest(MaintenanceRequest request)
    {
        maintenanceRequests.Add(request);
        Console.WriteLine($"Maintenance request added: {request.Issue}");
    }

    public List<MaintenanceRequest> GetMaintenanceRequests()
    {
        return maintenanceRequests;
    }

    internal void ResolveRequest(string details)
    {
        throw new NotImplementedException();
    }

}
