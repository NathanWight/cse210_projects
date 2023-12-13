namespace FinalProject;
public class Person
{
   
    public int Age { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }

    public Person(string name, int age, string username, string password)
    {
        Name = name;
        Age = age;
        Username = username;
        Password = password;
    }

    public string Name { get; private set; }

    public Person(string name)
    {
        Name = name;
    }
    

    
}
