using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your first name?.");
        String firstname = Console.ReadLine();

        Console.Write("what is your last name?.");
        String lastname = Console.ReadLine();

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}." );
    }
}