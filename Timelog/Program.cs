using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using Timelog.Models;
using System.Globalization;
using System.Data;
using Timelog.Utilities;

namespace Timelog
{
    class Program
    {
        static DateTime? startDate = DateTime.Today.AddDays(-8);
        static DateTime? endDate = DateTime.Today;

        static void Main(string[] args)
        {

            if (args.Length >= 1 && args.Length <= 3)
            {


                if (args.Length == 2 )
                {
                    if (args[1] == "3m")
                    {
                        startDate = DateTime.Today.AddMonths(-3);
                        Console.WriteLine("Getting data for the last 3 months");
                        RunArgumentCommands(args, false);

                    }
                    else
                    {
                        Console.WriteLine("The second argument you have entered: " + args[1] + " is wrong. ");
                        Console.WriteLine("The only accepted value is 3m in oreder to retrieve data for the last 3 months");
                    }
                }
                else
                {
                    RunArgumentCommands(args, true);
                }
               
            }
            else
            {
                Console.WriteLine("You have entered an incorect number of arguments, please try again");
                ConsoleCommandUtils.PrintCommandsFormat();
                ConsoleCommandUtils.PrintListOfCommands();
            }  
              
           
            Console.WriteLine("----Finished-----");
            
            
        }

        static void RunArgumentCommands(string[] args, bool setDates)
        {
            if (setDates)
                SetDates(args);

            switch (args[0])
            {
                case "p":
                    Console.WriteLine("Retrieve projects");
                    ConsoleCommandUtils.SaveProjects();
                    break;
                case "wu":
                    Console.WriteLine("Retrieve work units");
                    ConsoleCommandUtils.SaveWorkUnits(startDate, endDate);
                    break;
                case "i":
                    Console.WriteLine("Retrieve invoices");
                    ConsoleCommandUtils.SaveInvoices(startDate, endDate);
                    break;
                case "ild":
                    Console.WriteLine("Retrieve invoice line details");
                    ConsoleCommandUtils.SaveInvoiceLineDetails(startDate, endDate);
                    break;
                case "il":
                    Console.WriteLine("Retrieve invoice lines");
                    ConsoleCommandUtils.SaveInvoiceLines(startDate, endDate);
                    break;
                case "e":
                    Console.WriteLine("Retrieve employees");
                    ConsoleCommandUtils.SaveEmployees();
                    break;
                case "d":
                    Console.WriteLine("Retrieve departments");
                    ConsoleCommandUtils.SaveDepartments();
                    break;
                case "all":
                    Console.WriteLine("Retrieve all"); ;
                    ConsoleCommandUtils.SaveProjects();
                    ConsoleCommandUtils.SaveWorkUnits(startDate, endDate);
                    ConsoleCommandUtils.SaveInvoices(startDate, endDate);
                    ConsoleCommandUtils.SaveInvoiceLineDetails(startDate, endDate);
                    ConsoleCommandUtils.SaveInvoiceLines(startDate, endDate);
                    ConsoleCommandUtils.SaveEmployees();
                    ConsoleCommandUtils.SaveDepartments();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    ConsoleCommandUtils.PrintListOfCommands();
                    break;
            }

        } 

        static void SetDates(string[] args)
        {
            if (args.Length == 3)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                bool validDates = DateTime.TryParse(args[1], out sDate) && DateTime.TryParse(args[2], out eDate);
                if (validDates)
                {
                    startDate = sDate;
                    endDate = eDate;
                }
                else
                    Console.WriteLine("Values entered are not valid dates, program will run with default values");
            }
            else
                Console.WriteLine("You have not entered any dates, program will run with default values");
        }

    }
}
