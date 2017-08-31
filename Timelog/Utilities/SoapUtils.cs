using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Timelog.Models;
using System.Xml;
using Timelog.Utilities;
using System.Globalization;

namespace Timelog.Utilities
{
    public static class SoapUtils
    {
        static string siteCode = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogSiteCode"].ConnectionString;
        static string apiID = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogApiID"].ConnectionString;
        static string apiPassword = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogApiPw"].ConnectionString;
        static TimelogServiceReference.ServiceSoapClient soapService = new TimelogServiceReference.ServiceSoapClient();
        // set values to 0 to return data for all the users
        static int workUnitID = 0;
        static int employeeID = 0;
        static int allocationID = 0;
        static int taskID = 0;
        static int projectID = 0;
        static int departmentID = 0;
        static int status = -2; // status must be set to -2 to get all projects
        static int customerID = 0;
        static int projectMangerID = 0;
        static int invoiceID = 0;
        static int invoiceLineDetailID = 0;
        static int invoiceLineID = 0;
        static string initials = string.Empty;


        public static List<WorkUnit> GetWorkUnitsFromSoap(DateTime? sDate, DateTime? eDate)
        {
            List<WorkUnit> workUnitsList = new List<WorkUnit>();
            DateTime? startDate = sDate;
            DateTime? endDate = eDate;
            //Retrieve data from soap web service
            XmlNode workUnits = soapService.GetWorkUnitsRaw(siteCode, apiID, apiPassword, workUnitID, employeeID, allocationID, taskID, projectID, departmentID, startDate, endDate);
            //Add retrieved data to list
            foreach (XmlNode workUnit in workUnits.ChildNodes)
            {

                WorkUnit wUnit = new WorkUnit();
                wUnit.ID = Int32.Parse(workUnit.Attributes["ID"].Value);
                foreach (XmlNode unitProperty in workUnit)
                {
                    switch (unitProperty.Name)
                    {
                        case "tlp:EmployeeID":
                            wUnit.EmployeeID = Int32.Parse(unitProperty.InnerText);
                            break;
                        case "tlp:EmployeeInitials":
                            wUnit.EmployeeInitials = unitProperty.InnerText;
                            break;
                        case "tlp:EmployeeFirstName":
                            wUnit.EmployeeFirstName = unitProperty.InnerText;
                            break;
                        case "tlp:EmployeeLastName":
                            wUnit.EmployeeLastName = unitProperty.InnerText;
                            break;
                        case "tlp:AllocationID":
                            wUnit.AllocationID = Int32.Parse(unitProperty.InnerText);
                            break;
                        case "tlp:TaskID":
                            wUnit.TaskID = Int32.Parse(unitProperty.InnerText);
                            break;
                        case "tlp:ProjectID":
                            wUnit.ProjectID = Int32.Parse(unitProperty.InnerText);
                            break;
                        case "tlp:Date":
                            wUnit.Date = DateTime.Parse(unitProperty.InnerText);
                            break;
                        case "tlp:Note":
                            wUnit.Note = unitProperty.InnerText;
                            break;
                        case "tlp:AdditionalTextField":
                            wUnit.AdditionalTextField = unitProperty.InnerText;
                            break;
                        case "tlp:RegHours":
                            wUnit.RegHours = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Billable":
                            wUnit.Billable = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:InvHours":
                            wUnit.InvHours = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:CostAmount":
                            wUnit.CostAmount = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegAmount":
                            wUnit.RegAmount = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:InvAmount":
                            wUnit.InvAmount = float.Parse(unitProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;

                    }
                }

                workUnitsList.Add(wUnit);
            }
            Console.WriteLine("Retrived work units data from web service");
            return workUnitsList;
        }


        public static List<Project> GetProjectFromSoap()
        {
            List<Project> projectsList = new List<Project>();
            //Retrieve data from soap web service
            XmlNode projects = soapService.GetProjectsRaw(siteCode, apiID, apiPassword,  projectID, status, customerID, projectMangerID);
            //Add retrieved data to list
            foreach (XmlNode project in projects.ChildNodes)
            {
                Project pro = new Project();
                pro.ID = Int32.Parse(project.Attributes["ID"].Value);
                foreach (XmlNode projectChildNode in project.ChildNodes)
                {
                    switch (projectChildNode.Name)
                    {
                        case "tlp:Name":
                            pro.Name = projectChildNode.InnerText;
                            break;
                        case "tlp:No":
                            pro.No = projectChildNode.InnerText;
                            break;
                        case "tlp:Status":
                            pro.Status = byte.Parse(projectChildNode.InnerText);
                            break;
                        case "tlp:CustomerID":
                            pro.CustomerID = Int32.Parse(projectChildNode.InnerText);
                            break;
                        case "tlp:CustomerName":
                            pro.CustomerName = projectChildNode.InnerText;
                            break;
                        case "tlp:CustomerNo":
                            pro.CustomerNo = projectChildNode.InnerText;
                            break;
                        case "tlp:PMID":
                            pro.PMID = Int32.Parse(projectChildNode.InnerText);
                            break;
                        case "tlp:PMInitials":
                            pro.PMInitials = projectChildNode.InnerText;
                            break;
                        case "tlp:PMFullName":
                            pro.PMFullName = projectChildNode.InnerText;
                            break;
                        case "tlp:ProjectTypeID":
                            pro.ProjectTypeID = Int32.Parse(projectChildNode.InnerText);
                            break;
                        case "tlp:ProjectTypeName":
                            pro.ProjectTypeName = projectChildNode.InnerText;
                            break;
                        case "tlp:ProjectCategoryID":
                            pro.ProjectCategoryID = Int32.Parse(projectChildNode.InnerText);
                            break;
                        case "tlp:ProjectCategoryName":
                            pro.ProjectCategoryName = projectChildNode.InnerText;
                            break;
                        case "tlp:BudgetAmountFixedPriceTasks":
                            pro.BudgetAmountFixedPriceTasks = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetAmountFixedPriceProject":
                            pro.BudgetAmountFixedPriceProject = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetAmountTimeAndMaterial":
                            pro.BudgetAmountTimeAndMaterial = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetAmountExpenses":
                            pro.BudgetAmountExpenses = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetAmountTravel":
                            pro.BudgetAmountTravel = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetHoursFixedPriceTasks":
                            pro.BudgetHoursFixedPriceTasks = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetHoursFixedPriceProject":
                            pro.BudgetHoursFixedPriceProject = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:BudgetHoursTimeAndMaterial":
                            pro.BudgetHoursTimeAndMaterial = float.Parse(projectChildNode.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;

                    }
                }

                projectsList.Add(pro);
            }
            Console.WriteLine("Retrived projects data from web service");
            return projectsList;
        }


        public static List<InvoiceLineDetail> GetInvoiceLineDetailsFromSoap(DateTime? sDate, DateTime? eDate)
        {
            List<InvoiceLineDetail> invoiceLineDetailList = new List<InvoiceLineDetail>();
            DateTime? startDate = sDate;
            DateTime? endDate = eDate;
            //Retrieve data from soap web service
            XmlNode invoiceLineDetails = soapService.GetInvoiceLineDetailsRaw(siteCode, apiID, apiPassword, invoiceLineDetailID, customerID, projectID, invoiceID, startDate, endDate);
            //Add retrieved data to list
            foreach (XmlNode invoiceLineDetail in invoiceLineDetails.ChildNodes)
            {

                InvoiceLineDetail ilDetail = new InvoiceLineDetail();
                ilDetail.ID = Int32.Parse(invoiceLineDetail.Attributes["ID"].Value);
                foreach (XmlNode detailProperty in invoiceLineDetail)
                {
                    switch (detailProperty.Name)
                    {
                        case "tlp:InvoiceLineID":
                            ilDetail.InvoiceLineID = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:InvoiceID":
                            ilDetail.InvoiceID = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:RegistrationDate":
                            ilDetail.RegistrationDate = DateTime.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:Text":
                            ilDetail.Text = detailProperty.InnerText;
                            break;
                        case "tlp:Units":
                            ilDetail.Units = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Rate":
                            ilDetail.Rate = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Amount":
                            ilDetail.Amount= float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:OriginalUnits":
                            ilDetail.OriginalUnits = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:OriginalRate":
                            ilDetail.OriginalRate = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:OriginalAmount":
                            ilDetail.OriginalAmount = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegistrationType":
                            ilDetail.RegistrationType = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:OriginalType":
                            ilDetail.OriginalType = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:EmployeeInitials":
                            ilDetail.EmployeeInitials = detailProperty.InnerText;
                            break;
                        case "tlp:TaskID":
                            ilDetail.TaskID = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:TaskName":
                            ilDetail.TaskName = detailProperty.InnerText;
                            break;
                        case "tlp:Quantity":
                            ilDetail.Quantity = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RateSystemCurrency":
                            ilDetail.RateSystemCurrency = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:AmountSystemCurrency":
                            ilDetail.AmountSystemCurrency = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegisteredQuantity":
                            ilDetail.RegisteredQuantity = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegisteredRateSystemCurrency":
                            ilDetail.RegisteredRateSystemCurrency = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegisteredAmountSystemCurrency":
                            ilDetail.RegisteredAmountSystemCurrency = float.Parse(detailProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RegistrationID":
                            ilDetail.RegistrationID = Int32.Parse(detailProperty.InnerText);
                            break;
                        case "tlp:UnitType":
                            ilDetail.UnitType = Int32.Parse(detailProperty.InnerText);
                            break;

                    }
                }

                invoiceLineDetailList.Add(ilDetail);
            }
            Console.WriteLine("Retrived invoice line details data from web service");
            return invoiceLineDetailList;
        }

        public static List<Invoice> GetInvoicesFromSoap(DateTime? sDate, DateTime? eDate)
        {
            List<Invoice> invoicesList = new List<Invoice>();
            status= -1; // status must be set to -1 to get all invoices
            DateTime? startDate = sDate;
            DateTime? endDate = eDate;
            //Retrieve data from soap web service
            XmlNode invoices = soapService.GetInvoicesRaw(siteCode, apiID, apiPassword, invoiceID, customerID, status, startDate, endDate);
            //Add retrieved data to list
            foreach (XmlNode invoice in invoices.ChildNodes)
            {

                Invoice inv = new Invoice();
                inv.ID = Int32.Parse(invoice.Attributes["ID"].Value);
                
                foreach (XmlNode invoiceProperty in invoice)
                {
                    switch (invoiceProperty.Name)
                    {
                        case "tlp:InvoiceNo":
                            inv.InvoiceNo = invoiceProperty.InnerText;
                            break;
                        case "tlp:Header":
                            inv.Header = invoiceProperty.InnerText;
                            break;
                        case "tlp:Text":
                            inv.Text = invoiceProperty.InnerText;
                            break;
                        case "tlp:InvoiceDate":
                            inv.InvoiceDate = DateTime.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:DueDate":
                            inv.DueDate = DateTime.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:Amount":
                            inv.Amount = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Status":
                            inv.Status = Int32.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:Type":
                            inv.Type = Int32.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:CustomerID":
                            inv.CustomerID = Int32.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:CustomerName":
                            inv.CustomerName = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerNo":
                            inv.CustomerNo = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerAddress1":
                            inv.CustomerAddress1 = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerZipCode":
                            inv.CustomerZipCode = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerCity":
                            inv.CustomerCity = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerState":
                            inv.CustomerState = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerCountry":
                            inv.CustomerCountry = invoiceProperty.InnerText;
                            break;
                        case "tlp:PaymentTermID":
                            inv.PaymentTermID = Int32.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:PaymentTermText":
                            inv.PaymentTermText = invoiceProperty.InnerText;
                            break;
                        case "tlp:CurrencyAbb":
                            inv.CurrencyAbb = invoiceProperty.InnerText;
                            break;
                        case "tlp:CurrencyRate":
                            inv.CurrencyRate = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:DefaultVAT":
                            inv.DefaultVAT = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:AddVAT":
                            inv.AddVAT = byte.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:NetAmount":
                            inv.NetAmount = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:NetAmountSystemCurrency":
                            inv.NetAmountSystemCurrency = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:VATIncluded":
                            inv.VATIncluded = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:VATIncludedSystemCurrency":
                            inv.VATIncludedSystemCurrency = float.Parse(invoiceProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:ProjectNo":
                            inv.ProjectNo = invoiceProperty.InnerText;
                            break;
                        case "tlp:PurchaseNo":
                            inv.PurchaseNo = invoiceProperty.InnerText;
                            break;
                        case "tlp:ContactFullName":
                            inv.ContactFullName = invoiceProperty.InnerText;
                            break;
                        case "tlp:DepartmentID":
                            inv.DepartmentID = Int32.Parse(invoiceProperty.InnerText);
                            break;
                        case "tlp:DepartmentTree":
                            inv.DepartmentTree = invoiceProperty.InnerText;
                            break;
                        case "tlp:ExternalInvoiceNo":
                            inv.ExternalInvoiceNo = invoiceProperty.InnerText;
                            break;
                        case "tlp:CustomerReference":
                            inv.CustomerReference = invoiceProperty.InnerText;
                            break;
                        case "tlp:ExternalInvoiceStatus":
                            inv.ExternalInvoiceStatus = invoiceProperty.InnerText;
                            break;
                    }
                }

                invoicesList.Add(inv);
            }
            Console.WriteLine("Retrived invoices data from web service");
            return invoicesList;
        }


        public static List<InvoiceLine> GetInvoiceLinesFromSoap(DateTime? sDate, DateTime? eDate)
        {
            List<InvoiceLine> invoiceLinesList = new List<InvoiceLine>();
            DateTime? startDate = sDate;
            DateTime? endDate = eDate;
            //Retrieve data from soap web service
            XmlNode invoiceLines = soapService.GetInvoiceLinesRaw(siteCode, apiID, apiPassword, invoiceLineID, customerID, projectID, invoiceID, startDate, endDate);
            //Add retrieved data to list
            foreach (XmlNode invoiceLine in invoiceLines.ChildNodes)
            {

                InvoiceLine invLine = new InvoiceLine();
                invLine.ID = Int32.Parse(invoiceLine.Attributes["ID"].Value);

                foreach (XmlNode invoiceLineProperty in invoiceLine)
                {
                    switch (invoiceLineProperty.Name)
                    {
                        case "tlp:InvoiceID":
                            invLine.InvoiceID = Int32.Parse(invoiceLineProperty.InnerText);
                            break;
                        case "tlp:InvoiceNo":
                            invLine.InvoiceNo = invoiceLineProperty.InnerText;
                            break;
                        case "tlp:Date":
                            invLine.Date = DateTime.Parse(invoiceLineProperty.InnerText);
                            break;
                        case "tlp:Text":
                            invLine.Text = invoiceLineProperty.InnerText;
                            break;
                        case "tlp:Quantity":
                            invLine.Quantity = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Rate":
                            invLine.Rate = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:RateSystemCurrency":
                            invLine.RateSystemCurrency = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Amount":
                            invLine.Amount = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;             
                        case "tlp:AmountSystemCurrency":
                            invLine.AmountSystemCurrency = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:ProjectID":
                            invLine.ProjectID = Int32.Parse(invoiceLineProperty.InnerText);
                            break;
                        case "tlp:ProjectName":
                            invLine.ProjectName = invoiceLineProperty.InnerText;
                            break;
                        case "tlp:ProjectNo":
                            invLine.ProjectNo = invoiceLineProperty.InnerText;
                            break;
                        case "tlp:VAT":
                            invLine.VAT = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:Discount":
                            invLine.Discount = float.Parse(invoiceLineProperty.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                            break;
                        case "tlp:UnitType":
                            invLine.UnitType = Int32.Parse(invoiceLineProperty.InnerText);
                            break;
                        case "tlp:ProductNo":
                            invLine.ProductNo = invoiceLineProperty.InnerText;
                            break;
                        
                    }
                }

                invoiceLinesList.Add(invLine);
            }
            Console.WriteLine("Retrived invoice lines data from web service");
            return invoiceLinesList;
        }

        public static List<Employee> GetEmployeesFromSoap()
        {
            List<Employee> employeesList = new List<Employee>();
            //Retrieve data from soap web service
            status = -1;
            XmlNode employees = soapService.GetEmployeesRaw(siteCode, apiID, apiPassword, employeeID, initials, departmentID, status);
            //Add retrieved data to list
            foreach (XmlNode employee in employees.ChildNodes)
            {

                Employee emp = new Employee();
                emp.ID = Int32.Parse(employee.Attributes["ID"].Value);

                foreach (XmlNode employeeProperty in employee)
                {
                    switch (employeeProperty.Name)
                    {
                        case "tlp:FirstName":
                            emp.FirstName = employeeProperty.InnerText;
                            break;
                        case "tlp:LastName":
                            emp.LastName = employeeProperty.InnerText;
                            break;
                        case "tlp:FullName":
                            emp.FullName = employeeProperty.InnerText;
                            break;
                        case "tlp:Initials":
                            emp.Initials = employeeProperty.InnerText;
                            break;
                        case "tlp:Title":
                            emp.Title = employeeProperty.InnerText;
                            break;
                        case "tlp:Email":
                            emp.Email = employeeProperty.InnerText;
                            break;
                        case "tlp:Phone":
                            emp.Phone = employeeProperty.InnerText;
                            break;
                        case "tlp:Mobile":
                            emp.Mobile = employeeProperty.InnerText;
                            break;
                        case "tlp:PrivatePhone":
                            emp.PrivatePhone = employeeProperty.InnerText;
                            break;
                        case "tlp:Address":
                            emp.Address = employeeProperty.InnerText;
                            break;
                        case "tlp:ZipCode":
                            emp.ZipCode = employeeProperty.InnerText;
                            break;
                        case "tlp:City":
                            emp.City = employeeProperty.InnerText;
                            break;
                        case "tlp:Status":
                            emp.Status = Int32.Parse(employeeProperty.InnerText);
                            break;
                        case "tlp:HiredDate":
                            emp.HiredDate = DateTime.Parse(employeeProperty.InnerText);
                            break;
                        case "tlp:TerminatedDate":
                            emp.TerminatedDate = DateTime.Parse(employeeProperty.InnerText);
                            break;
                        case "tlp:DepartmentNameID":
                            emp.DepartmentNameID = Int32.Parse(employeeProperty.InnerText);
                            break;
                        case "tlp:DepartmentName":
                            emp.DepartmentName = employeeProperty.InnerText;
                            break;

                    }
                }

                employeesList.Add(emp);
            }
            Console.WriteLine("Retrived employee data from web service");
            return employeesList;
        }


        public static List<Department> GetDepartmentsFromSoap()
        {
            List<Department> departmentsList = new List<Department>();
            //Retrieve data from soap web service
            XmlNode departments = soapService.GetDepartmentsShortList(siteCode, apiID, apiPassword);
            //Add retrieved data to list
            foreach (XmlNode department in departments.ChildNodes)
            {

                Department dep = new Department();
                dep.ID = Int32.Parse(department.Attributes["ID"].Value);

                foreach (XmlNode departmentProperty in department)
                {
                    switch (departmentProperty.Name)
                    {
                        case "tlp:Name":
                            dep.Name = departmentProperty.InnerText;
                            break;
                        case "tlp:ParentID":
                            dep.ParentID = Int32.Parse(departmentProperty.InnerText);
                            break;
                    }
                }

                departmentsList.Add(dep);
            }
            Console.WriteLine("Retrived departments data from web service");
            return departmentsList;
        }

    }
}
