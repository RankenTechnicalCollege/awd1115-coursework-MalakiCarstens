// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Project8;

Dictionary<string, double> items = new Dictionary<string, double>();
items.Add("Lollipop", 2.5);
items.Add("Gum", 1.5);
items.Add("Soda", 3.75);

Cart cart1 = new Cart("1234");
cart1.AddItem("Lollipop", 2.5);
cart1.AddItem("Gum", 1.5);
Console.WriteLine(cart1);

cart1.RemoveItem("Gum");
Console.WriteLine(cart1);

Cart cart2 = new Cart("5124");
cart2.AddItem("Milk", 2.5);
cart2.AddItem("Bread", 1.5);
cart2.AddItem("Eggs", 3.75);
Console.WriteLine(cart2);