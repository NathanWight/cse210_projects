

namespace FinalProject;
 class Program
    {
        static void Main(string[] args)
        {   Console.WriteLine("Menu Options:");
            Console.WriteLine("1: Tenant");
            Console.WriteLine("2: Manager");
            int user = int.Parse(Console.ReadLine());
           
            if (user == 1){ 
            TenantManagementSystem tenantSystem = new TenantManagementSystem();
            tenantSystem.Start();
            }
            if (user== 2){
                Menu manager = new Menu();
                manager.StartMenu();
            }
        }
    }
