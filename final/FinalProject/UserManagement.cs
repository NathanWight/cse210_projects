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
    
        static void SaveUsernamesToFile()
        {
            string fileName = "usernames.txt";
            Console.WriteLine($"Saving usernames to {fileName}...");

            // Here, usernames could be stored in a list or obtained from wherever they are stored in your program
            string[] usernames = Array.Empty<string>(); // Replace this with your actual usernames

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string username in usernames)
                    {
                        writer.WriteLine(username);
                    }
                }

                Console.WriteLine("Usernames saved successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while saving: {e.Message}");
            }
        }
    }


    // Other authentication methods...

