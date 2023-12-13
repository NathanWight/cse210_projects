namespace FinalProject;
public interface IRentable
{
    void Rent(Tenant tenant);
    void Vacate();
}