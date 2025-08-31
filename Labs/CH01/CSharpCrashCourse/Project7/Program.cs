// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

bool exit = false;
Dictionary<string, string> phoneBook = new();
phoneBook.Add("Malaki", "123-456-7890");
phoneBook.Add("Evan", "314-867-5309");
phoneBook.Add("Moe", "893-003-5578");

do
{
    Console.WriteLine("\n 1. Add Contact \n 2. View Contact \n 3. Update Contact \n 4. Delete");
    Console.Write("Enter Choice: ");
    string? choice = Console.ReadLine();
    if (choice.Equals("6"))
    {
        exit = true;
    }
    else if (choice.Equals("1"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        phoneBook.Add(name, phoneNumber);
    }
    else if (choice.Equals("2"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        if (phoneBook.ContainsKey(name))
        {
            Console.WriteLine($"\n Name: {name} \n Phone Number: {phoneBook[name]}");
        }
        else
        {
            Console.WriteLine("Contact Not Found"); 
        }
    }
    else
    {
        Console.WriteLine("Conctact Not Found");
    }

  }
    while (exit == false) ;