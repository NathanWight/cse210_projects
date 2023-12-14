

namespace FinalProject
{
    public class UserManagement
    {
        private Dictionary<string, string> tenants; // Username, Password for tenants
        private Dictionary<string, string> managers; // Username, Password for property managers
        private Dictionary<string, string> staff; // Username, Password for staff members

        public UserManagement()
        {
            tenants = new Dictionary<string, string>();
            managers = new Dictionary<string, string>();
            staff = new Dictionary<string, string>();

            // Adding some sample data
            tenants.Add("tenant1", "pass1");
            tenants.Add("tenant2", "pass2");

            managers.Add("manager1", "pass1");
            managers.Add("manager2", "pass2");

            staff.Add("staff1", "pass1");
            staff.Add("staff2", "pass2");
        }

        public bool AddTenant(string username, string password)
        {
            if (!tenants.ContainsKey(username))
            {
                tenants.Add(username, password);
                return true;
            }
            return false; // Username already exists
        }

        public bool AddManager(string username, string password)
        {
            if (!managers.ContainsKey(username))
            {
                managers.Add(username, password);
                return true;
            }
            return false; // Username already exists
        }

        public bool AddStaff(string username, string password)
        {
            if (!staff.ContainsKey(username))
            {
                staff.Add(username, password);
                return true;
            }
            return false; // Username already exists
        }

        public bool AuthenticateTenant(string username, string password)
        {
            if (tenants.ContainsKey(username) && tenants[username] == password)
            {
                return true; // Username and password match
            }
            return false; // Username or password doesn't match
        }

        public bool AuthenticateManager(string username, string password)
        {
            if (managers.ContainsKey(username) && managers[username] == password)
            {
                return true; // Username and password match
            }
            return false; // Username or password doesn't match
        }

        public bool AuthenticateStaff(string username, string password)
        {
            if (staff.ContainsKey(username) && staff[username] == password)
            {
                return true; // Username and password match
            }
            return false; // Username or password doesn't match
        }

        public Tenant GetTenant(string username)
        {
            // Access your data source to retrieve tenant details based on username
            // This can be fetching data from a database, a file, etc.

           
            if (tenants.ContainsKey(username))
            {
                // Create a Tenant object using the retrieved username
                return new Tenant(username);
            }

            return null; // Return null if the username doesn't exist in the data source
        }
    }
}
