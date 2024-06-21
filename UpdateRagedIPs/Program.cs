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


    while (option == 0)
    {
        Console.WriteLine("Select \n[1] for Start\n[2] Take all website and take RangedIPs \n[3] for Close Application");
        option = Convert.ToInt16(Console.ReadLine());


        switch (option)
        {
            case 1:
                Console.WriteLine("Starting...");
                Start.getRangeIPS();
                break;
            case 2:
                Console.WriteLine("Take all website and take RangedIPs...");
                Start.ReadAllDomains();
                break;
            case 3:
                Environment.Exit(0);
                break;
        }

    }
}
catch (Exception err) { Console.WriteLine(err.StackTrace);}
