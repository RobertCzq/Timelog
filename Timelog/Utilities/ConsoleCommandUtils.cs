using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelog.Models;

namespace Timelog.Utilities
{
    public static class ConsoleCommandUtils
    {
        public static void SaveWorkUnits(DateTime? startDate, DateTime? endDate)
        {
            List<WorkUnit> workUnitsList = new List<WorkUnit>();
            workUnitsList = SoapUtils.GetWorkUnitsFromSoap(startDate, endDate);
            string workUnitsTable = System.Configuration.ConfigurationManager.ConnectionStrings["WorkUnitsTable"].ConnectionString;
            DbUtils.SaveWorkUnitsToDb(workUnitsTable, startDate, endDate, workUnitsList);
        }

        public static void SaveProjects()
        {
            List<Project> projectsList = new List<Project>();
            projectsList = SoapUtils.GetProjectFromSoap();
            string projectsTable = System.Configuration.ConfigurationManager.ConnectionStrings["ProjectsTable"].ConnectionString;
            DbUtils.SaveProjectsToDb(projectsTable, projectsList);
        }

        public static void SaveInvoiceLineDetails(DateTime? startDate, DateTime? endDate)
        {

            List<InvoiceLineDetail> invoiceLineDetailList = new List<InvoiceLineDetail>();
            invoiceLineDetailList = SoapUtils.GetInvoiceLineDetailsFromSoap(startDate, endDate);
            string invoiceLineDetailsTable = System.Configuration.ConfigurationManager.ConnectionStrings["InvoiceLineDetailsTable"].ConnectionString;
            DbUtils.SaveInvoiceLineDetailsToDb(invoiceLineDetailsTable, startDate, endDate, invoiceLineDetailList);
        }

        public static void SaveInvoices(DateTime? startDate, DateTime? endDate)
        {
            List<Invoice> invoicesList = new List<Invoice>();
            invoicesList = SoapUtils.GetInvoicesFromSoap(startDate, endDate);
            string invoicesTable = System.Configuration.ConfigurationManager.ConnectionStrings["InvoicesTable"].ConnectionString;
            DbUtils.SaveInvoicesToDb(invoicesTable, startDate, endDate, invoicesList);
        }

        public static void SaveInvoiceLines(DateTime? startDate, DateTime? endDate)
        {
            List<InvoiceLine> invoiceLinesList = new List<InvoiceLine>();
            invoiceLinesList = SoapUtils.GetInvoiceLinesFromSoap(startDate, endDate);
            string invoiceLinesTable = System.Configuration.ConfigurationManager.ConnectionStrings["InvoiceLinesTable"].ConnectionString;
            DbUtils.SaveInvoiceLinesToDb(invoiceLinesTable, startDate, endDate, invoiceLinesList);
        }

        public static void SaveEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList = SoapUtils.GetEmployeesFromSoap();
            string employeesTable = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeesTable"].ConnectionString;
            DbUtils.SaveEmployeesToDb(employeesTable, employeeList);
        }

        public static void SaveDepartments()
        {
            List<Department> departmentsList = new List<Department>();
            departmentsList = SoapUtils.GetDepartmentsFromSoap();
            string departmentsTable = System.Configuration.ConfigurationManager.ConnectionStrings["DepartmentsTable"].ConnectionString;
            DbUtils.SaveDepartmentsToDb(departmentsTable, departmentsList);
        }

        public static void PrintCommandsFormat()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("You can enter commands in the formats :");
            Console.WriteLine("Timelog.exe command");
            Console.WriteLine("Timelog.exe command 3m");
            Console.WriteLine("Timelog.exe command startDate endDate");
            Console.WriteLine("startDate endDate must respect the format dd-mm-yyyy");
            Console.WriteLine("If startDate and endDate are not defined the default is endDate = today and startDate = today - 8");

        }

        public static void PrintListOfCommands()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List of commands:");
            Console.WriteLine("Timelog.exe [p/wu/i/ild/il/e/d/all] startDate endDate");
            Console.WriteLine("Timelog.exe [p/wu/i/ild/il/e/d/all] 3m  --- retrieves data for the last 3 months on the specified command");
            Console.WriteLine("Timelog.exe p                       --- retrieves all projects");
            Console.WriteLine("Timelog.exe e                       --- retrieves all employees");
            Console.WriteLine("Timelog.exe d                       --- retrieves all departments");
            Console.WriteLine("Timelog.exe wu startDate endDate    --- retrieves all work units between dates");
            Console.WriteLine("Timelog.exe i startDate endDate     --- retrieves all invoices between dates");
            Console.WriteLine("Timelog.exe ild startDate endDate   --- retrieves all invoice line details between dates");
            Console.WriteLine("Timelog.exe il startDate endDate    --- retrieves all invoice lines between dates");
            Console.WriteLine("Timelog.exe all startDate endDate   --- retrieves all between dates");
            Console.WriteLine("If startDate and endDate are not defined the default is endDate = today and startDate = today - 8");

        }
    }
}
