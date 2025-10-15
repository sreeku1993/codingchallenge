using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter keys (Ends with '#'):");
        string input = Console.ReadLine(); //Reads the input
        string result = OldPhonePadSetup.OldPhonePad(input); //get the result
        Console.WriteLine($"Output: {result}");
    }
}
