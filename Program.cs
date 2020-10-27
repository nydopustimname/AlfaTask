using System;

namespace AlfaTask
{
    class Program
    {
        static void Main(string[] args)
        {
            AddToTable table = new AddToTable();
            table.CreateTable();
           
            Console.WriteLine("Done, path to file - Current Folder");
            Console.ReadLine();
        }
    }
}
