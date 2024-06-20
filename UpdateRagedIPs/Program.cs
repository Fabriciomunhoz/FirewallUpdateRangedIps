// See https://aka.ms/new-console-template for more information
using UpdateRagedIPs;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Program by Faluckes");
Console.WriteLine("Github: https://github.com/Faluckes \nContact:faluckesdev@protonmail.com\n");

Console.WriteLine("\nSearch IPs\n");
var Start = new GetIPS();
var option = 0;
try
{


    while (!(option == 1 || option == 2))
    {
        Console.WriteLine("Select [1] for Start\nSelect [2] for Close Application");
        option = Convert.ToInt16(Console.ReadLine());

        if (option == 1)
        {
            Console.WriteLine("Starting...");
            Start.getRangeIPS();
        }

        if (option == 2)
        {
            Environment.Exit(0);
        }
    }
}
catch (Exception err) { Console.WriteLine(err.StackTrace); }
