// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//VALUE TYPES

//byte - 0 - 255
//sbyte -127 though 128
//short - 16 bits
//int 32 bits
//uint - 0 - 4 billion
//long 64 bits
//chars

//Signed or Unsighned

//floats 32 bits
//doubles 64 bits
//decimal 128 bits

//booleans

//REFERENCE or OBJECT
//String
//Objects
//Arrays
//Interfaces
//Dynamic
//Pointer


Console.WriteLine("Please enter your name:");
string name = Console.ReadLine();
Console.WriteLine("Please enter your age");
int userAge = Convert.ToInt32(Console.ReadLine());

char letter = 'a';

Console.WriteLine($"Hello {name}. You are {userAge} years old.");