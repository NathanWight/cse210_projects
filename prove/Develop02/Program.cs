using System.Net;
using Develop02;


class Program
{
    static void Main(string[] args)
    {  
            Journal toJournal = new Journal();
            // A list of prompts for the user to write about
            List<string> prompts = new List<string>()
            {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the highlight of my day?",
            "What was something funny that happend?"
            };

            Console.WriteLine("What would you like to do:");
            Console.WriteLine("[1] Write");
            Console.WriteLine("[2] Display");
            Console.WriteLine("[3] Load");
            Console.WriteLine("[4] Save");
            Console.WriteLine("[5] Quit");
            //Store the users input  
            int choice = Convert.ToInt32(Console.ReadLine()); 
            // Try and Catch the user choice to make sure it is within range
            
            
            

            
    
    // start loop and run until user selects 5 to quit
    while (choice != 5) 
    {
        

       if (choice == 1)
       { // Write to the list in Journal.cs
                    
                    Random random = new Random();
                    int num = random.Next(0, 6);//Number min 0 and max 6

                    Entrys entry1 = new Entrys();//Use the constructor of class Entry
                    // select a random prompt
                    entry1.prompt = prompts[num];
                    string prompt = entry1.prompt;
                    Console.WriteLine(entry1.prompt);
                    //Get from the response from the user
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    // get the current date
                    string date = entry1.Date;
                    // send each property to the list in Journal.cs
                    toJournal.entries.Add($"\n{date}, \n{prompt}:\n{response}");
                  

        
       
        
       }

       if (choice == 2)
       {   // Call Display method
            toJournal.Display();
       }
       
       if (choice == 3)
       {  // Load a file
      
       Console.WriteLine("What file would you like to load?");
       // get the file name 
       string loadFile = Console.ReadLine();
       // open the file and read all the lines 
       string[] lines = System.IO.File.ReadAllLines(loadFile);
        // read each line into the list in Journal.cs    
        foreach (string line in lines)
            {   //print the journal entries in the console
                Console.WriteLine(line);
                toJournal.entries.Add(line);                            
            }

       }

       if (choice == 4)
       {   // Save
        Console.WriteLine("What file would you like to save?");
        string fileName = Console.ReadLine();
        // Use stream writer to append the file selected
        using (StreamWriter outputFile = File.AppendText(fileName))
{
        // iterate through the list in Journal.cs and write it to the file selected
        foreach (var entry in toJournal.entries)  
        {  
            outputFile.WriteLine(entry); 
            Console.WriteLine(entry);
        }  
            
            
}

       }
        // Display the options to the user
        Console.WriteLine("What would you like to do:");
        Console.WriteLine("[1] Write");
        Console.WriteLine("[2] Display");
        Console.WriteLine("[3] Load");
        Console.WriteLine("[4] Save");
        Console.WriteLine("[5] Quit");
        //Store the users input  
        choice = Convert.ToInt32(Console.ReadLine()); 
        
    }
       
    }
         
    }
