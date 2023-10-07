namespace Develop02;
using System.IO; 

    public class Journal
    { 
        
        public List<string> entries = new List<string>();

        public void Display()
        {
            foreach (var entry in entries)  
        {  
            Console.WriteLine(entry);  
        }  
        }
        

    }
