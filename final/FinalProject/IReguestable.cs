namespace FinalProject;
public interface IRequestable
{
    void AddMaintenanceRequest(string issue);
    void ResolveMaintenanceRequest(int requestId);
}
