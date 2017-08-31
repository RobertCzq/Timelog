using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelog.Models;


namespace Timelog.Utilities
{
    public static class DbUtils
    {
        public static void SaveWorkUnitsToDb(string table, DateTime? startDate, DateTime? endDate, List<WorkUnit> workUnits)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString; 
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean db if items exist from those dates
                string sDate = ((DateTime)startDate).ToString("yyyy-MM-dd");
                string eDate = ((DateTime)endDate).ToString("yyyy-MM-dd");
                string deleteCommand = "DELETE FROM " + table + " WHERE Date BETWEEN '" + sDate + "' AND '" + eDate + "'";
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the WorkUnits table");
                }

                //Insert work units into db
                foreach (WorkUnit workUnit in workUnits)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, EmployeeID, EmployeeInitials, "
                           + "EmployeeFirstName, EmployeeLastName, AllocationID, TaskID, ProjectID, Date, Note, "
                           + "AdditionalTextField, RegHours, Billable, InvHours, CostAmount, RegAmount, InvAmount)"
                           + " VALUES (@ID, @EmployeeID, @EmployeeInitials, @EmployeeFirstName, @EmployeeLastName,"
                           + " @AllocationID, @TaskID, @ProjectID, @Date, @Note, @AdditionalTextField, @RegHours,"
                           + " @Billable, @InvHours, @CostAmount, @RegAmount, @InvAmount)";

                  
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = workUnit.ID;
                        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = workUnit.EmployeeID;
                        command.Parameters.Add("@EmployeeInitials", SqlDbType.VarChar).Value = workUnit.EmployeeInitials;
                        command.Parameters.Add("@EmployeeFirstName", SqlDbType.VarChar).Value = workUnit.EmployeeFirstName;
                        command.Parameters.Add("@EmployeeLastName", SqlDbType.VarChar).Value = workUnit.EmployeeLastName;
                        command.Parameters.Add("@AllocationID", SqlDbType.Int).Value = workUnit.AllocationID;
                        command.Parameters.Add("@TaskID", SqlDbType.Int).Value = workUnit.TaskID;
                        command.Parameters.Add("@ProjectID", SqlDbType.Int).Value = workUnit.ProjectID;
                        command.Parameters.Add("@Date", SqlDbType.DateTime).Value = workUnit.Date;
                        if (workUnit.Note == null)
                            command.Parameters.Add("@Note", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Note", SqlDbType.VarChar).Value = workUnit.Note;

                        command.Parameters.Add("@AdditionalTextField", SqlDbType.VarChar).Value = workUnit.AdditionalTextField;
                        command.Parameters.Add("@RegHours", SqlDbType.Float).Value = workUnit.RegHours;
                        command.Parameters.Add("@Billable", SqlDbType.Float).Value = workUnit.Billable;
                        command.Parameters.Add("@InvHours", SqlDbType.Float).Value = workUnit.InvHours;
                        command.Parameters.Add("@CostAmount", SqlDbType.Float).Value = workUnit.CostAmount;
                        command.Parameters.Add("@RegAmount", SqlDbType.Float).Value = workUnit.RegAmount;
                        command.Parameters.Add("@InvAmount", SqlDbType.Float).Value = workUnit.InvAmount;
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into WorkUnits table"); 
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SaveProjectsToDb(string table, List<Project> projects)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table projects
                string deleteCommand = "DELETE FROM " + table ;
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the Projects table");
                }

                //Insert work units into db
                foreach (Project project in projects)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, Name, No, Status, CustomerID, CustomerName, CustomerNo, "
                           + "PMID, PMInitials, PMFullName, ProjectTypeID, ProjectTypeName, ProjectCategoryID, ProjectCategoryName, "
                           + "BudgetAmountFixedPriceTasks, BudgetAmountFixedPriceProject, BudgetAmountTimeAndMaterial, "
                           + "BudgetAmountExpenses, BudgetAmountTravel, BudgetHoursFixedPriceTasks, BudgetHoursFixedPriceProject, "
                           + "BudgetHoursTimeAndMaterial)"
                           + " VALUES (@ID, @Name, @No, @Status, @CustomerID, @CustomerName, @CustomerNo, @PMID, @PMInitials,"
                           + " @PMFullName, @ProjectTypeID, @ProjectTypeName, @ProjectCategoryID, @ProjectCategoryName,"
                           + " @BudgetAmountFixedPriceTasks, @BudgetAmountFixedPriceProject, @BudgetAmountTimeAndMaterial,"
                           + " @BudgetAmountExpenses, @BudgetAmountTravel, @BudgetHoursFixedPriceTasks, @BudgetHoursFixedPriceProject,"
                           + " @BudgetHoursTimeAndMaterial)";
                    
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = project.ID;

                        if (project.Name == null)
                            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = project.Name;

                        if (project.No == null)
                            command.Parameters.Add("@No", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@No", SqlDbType.VarChar).Value = project.No;

                        command.Parameters.Add("@Status", SqlDbType.Bit).Value = project.Status;
                        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = project.CustomerID;

                        if (project.CustomerName == null)
                            command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = project.CustomerName;

                        if (project.CustomerNo == null)
                            command.Parameters.Add("@CustomerNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@CustomerNo", SqlDbType.VarChar).Value = project.CustomerNo;

                        command.Parameters.Add("@PMID", SqlDbType.Int).Value = project.PMID;

                        if (project.PMInitials == null)
                            command.Parameters.Add("@PMInitials", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@PMInitials", SqlDbType.VarChar).Value = project.PMInitials;

                        if (project.PMFullName == null)
                            command.Parameters.Add("@PMFullName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@PMFullName", SqlDbType.VarChar).Value = project.PMFullName;

                        command.Parameters.Add("@ProjectTypeID", SqlDbType.Int).Value = project.ProjectTypeID;

                        if (project.ProjectTypeName == null)
                            command.Parameters.Add("@ProjectTypeName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProjectTypeName", SqlDbType.VarChar).Value = project.ProjectTypeName;
                        command.Parameters.Add("@ProjectCategoryID", SqlDbType.Int).Value = project.ProjectCategoryID;
                   
                        if (project.ProjectCategoryName == null)
                            command.Parameters.Add("@ProjectCategoryName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProjectCategoryName", SqlDbType.VarChar).Value = project.ProjectCategoryName;

                        command.Parameters.Add("@BudgetAmountFixedPriceTasks", SqlDbType.Float).Value = project.BudgetAmountFixedPriceTasks;
                        command.Parameters.Add("@BudgetAmountFixedPriceProject", SqlDbType.Float).Value = project.BudgetAmountFixedPriceProject;
                        command.Parameters.Add("@BudgetAmountTimeAndMaterial", SqlDbType.Float).Value = project.BudgetAmountTimeAndMaterial;
                        command.Parameters.Add("@BudgetAmountExpenses", SqlDbType.Float).Value = project.BudgetAmountExpenses;
                        command.Parameters.Add("@BudgetAmountTravel", SqlDbType.Float).Value = project.BudgetAmountTravel;
                        command.Parameters.Add("@BudgetHoursFixedPriceTasks", SqlDbType.Float).Value = project.BudgetHoursFixedPriceTasks;
                        command.Parameters.Add("@BudgetHoursFixedPriceProject", SqlDbType.Float).Value = project.BudgetHoursFixedPriceProject;
                        command.Parameters.Add("@BudgetHoursTimeAndMaterial", SqlDbType.Float).Value = project.BudgetHoursTimeAndMaterial;
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into Projects table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SaveInvoiceLineDetailsToDb(string table, DateTime? startDate, DateTime? endDate, List<InvoiceLineDetail> invoiceLineDetails)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table if items exist from those dates
                string sDate = ((DateTime)startDate).ToString("yyyy-MM-dd");
                string eDate = ((DateTime)endDate).ToString("yyyy-MM-dd");
                string deleteCommand = "DELETE FROM " + table + " WHERE RegistrationDate BETWEEN '" + sDate + "' AND '" + eDate + "'";
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the InvoiceLineDetails table");
                }

                //Insert invoice line details into db
                foreach (InvoiceLineDetail invoiceLineDetail in invoiceLineDetails)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, InvoiceLineID, InvoiceID, RegistrationDate, "
                           + "Text, Units, Rate, Amount, OriginalUnits, OriginalRate, OriginalAmount, RegistrationType, "
                           + "OriginalType, EmployeeInitials, TaskID, TaskName, Quantity, RateSystemCurrency, "
                           + "AmountSystemCurrency, RegisteredQuantity, RegisteredRateSystemCurrency, RegisteredAmountSystemCurrency, "
                           + "RegistrationID, UnitType)"
                           + " VALUES (@ID, @InvoiceLineID, @InvoiceID, @RegistrationDate, @Text, @Units, @Rate, @Amount,"
                           + " @OriginalUnits, @OriginalRate, @OriginalAmount, @RegistrationType, @OriginalType,"
                           + " @EmployeeInitials, @TaskID, @TaskName, @Quantity, @RateSystemCurrency, @AmountSystemCurrency,"
                           + " @RegisteredQuantity, @RegisteredRateSystemCurrency, @RegisteredAmountSystemCurrency, @RegistrationID,"
                           + " @UnitType)";
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = invoiceLineDetail.ID;
                        command.Parameters.Add("@InvoiceLineID", SqlDbType.Int).Value = invoiceLineDetail.InvoiceLineID;
                        command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceLineDetail.InvoiceID;
                        command.Parameters.Add("@RegistrationDate", SqlDbType.DateTime).Value = invoiceLineDetail.RegistrationDate;

                        if (invoiceLineDetail.Text == null)
                            command.Parameters.Add("@Text", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Text", SqlDbType.VarChar).Value = invoiceLineDetail.Text;

                        command.Parameters.Add("@Units", SqlDbType.Float).Value = invoiceLineDetail.Units;
                        command.Parameters.Add("@Rate", SqlDbType.Float).Value = invoiceLineDetail.Rate;
                        command.Parameters.Add("@Amount", SqlDbType.Float).Value = invoiceLineDetail.Amount;
                        command.Parameters.Add("@OriginalUnits", SqlDbType.Float).Value = invoiceLineDetail.OriginalUnits;
                        command.Parameters.Add("@OriginalRate", SqlDbType.Float).Value = invoiceLineDetail.OriginalRate;
                        command.Parameters.Add("@OriginalAmount", SqlDbType.Float).Value = invoiceLineDetail.OriginalAmount;
                        command.Parameters.Add("@RegistrationType", SqlDbType.Int).Value = invoiceLineDetail.RegistrationType;
                        command.Parameters.Add("@OriginalType", SqlDbType.Int).Value = invoiceLineDetail.OriginalType;

                        if (invoiceLineDetail.EmployeeInitials == null)
                            command.Parameters.Add("@EmployeeInitials", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@EmployeeInitials", SqlDbType.VarChar).Value = invoiceLineDetail.EmployeeInitials;

                        command.Parameters.Add("@TaskID", SqlDbType.Int).Value = invoiceLineDetail.TaskID;

                        if (invoiceLineDetail.TaskName == null)
                            command.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = invoiceLineDetail.TaskName;
                    
                        command.Parameters.Add("@Quantity", SqlDbType.Float).Value = invoiceLineDetail.Quantity;
                        command.Parameters.Add("@RateSystemCurrency", SqlDbType.Float).Value = invoiceLineDetail.RateSystemCurrency;
                        command.Parameters.Add("@AmountSystemCurrency", SqlDbType.Float).Value = invoiceLineDetail.AmountSystemCurrency;
                        command.Parameters.Add("@RegisteredQuantity", SqlDbType.Float).Value = invoiceLineDetail.RegisteredQuantity;
                        command.Parameters.Add("@RegisteredRateSystemCurrency", SqlDbType.Float).Value = invoiceLineDetail.RegisteredRateSystemCurrency;
                        command.Parameters.Add("@RegisteredAmountSystemCurrency", SqlDbType.Float).Value = invoiceLineDetail.RegisteredAmountSystemCurrency;
                        command.Parameters.Add("@RegistrationID", SqlDbType.Int).Value = invoiceLineDetail.RegistrationID;
                        command.Parameters.Add("@UnitType", SqlDbType.Int).Value = invoiceLineDetail.UnitType;
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into  InvoiceLineDetails table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SaveInvoicesToDb(string table, DateTime? startDate, DateTime? endDate, List<Invoice> invoices)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table if items exist from those dates
                string sDate = ((DateTime)startDate).ToString("yyyy-MM-dd");
                string eDate = ((DateTime)endDate).ToString("yyyy-MM-dd");
                string deleteCommand = "DELETE FROM " + table + " WHERE InvoiceDate BETWEEN '" + sDate + "' AND '" + eDate + "'";
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the Invoices table");
                }

                //Insert invoice line details into db
                foreach (Invoice invoice in invoices)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, InvoiceNo, Header, Text, InvoiceDate, DueDate, "
                           + "Amount, Status, Type, CustomerID, CustomerName, CustomerNo, CustomerAddress1, "
                           + "CustomerZipCode, CustomerCity, CustomerState, CustomerCountry, PaymentTermID, "
                           + "PaymentTermText, CurrencyAbb, CurrencyRate, DefaultVAT, AddVAT, NetAmount, "
                           + "NetAmountSystemCurrency, VATIncluded, VATIncludedSystemCurrency, ProjectNo, PurchaseNo, "
                           + "ContactFullName, DepartmentID, DepartmentTree, ExternalInvoiceNo, CustomerReference, "
                           + "ExternalInvoiceStatus)"
                           + " VALUES (@ID, @InvoiceNo, @Header, @Text, @InvoiceDate, @DueDate, @Amount, @Status,"
                           + " @Type, @CustomerID, @CustomerName, @CustomerNo, @CustomerAddress1, @CustomerZipCode,"
                           + " @CustomerCity, @CustomerState, @CustomerCountry, @PaymentTermID, @PaymentTermText,"
                           + " @CurrencyAbb, @CurrencyRate, @DefaultVAT, @AddVAT, @NetAmount, @NetAmountSystemCurrency,"
                           + " @VATIncluded, @VATIncludedSystemCurrency, @ProjectNo, @PurchaseNo, @ContactFullName,"
                           + " @DepartmentID, @DepartmentTree, @ExternalInvoiceNo, @CustomerReference,"
                           + " @ExternalInvoiceStatus)";
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = invoice.ID;
                        command.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = invoice.InvoiceNo;
                        command.Parameters.Add("@Header", SqlDbType.VarChar).Value = invoice.Header;
                        command.Parameters.Add("@Text", SqlDbType.VarChar).Value = invoice.Text;
                        command.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = invoice.InvoiceDate;

                        if (invoice.DueDate == DateTime.MinValue)
                            command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = invoice.DueDate;

                        command.Parameters.Add("@Amount", SqlDbType.Float).Value = invoice.Amount;
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = invoice.Status;
                        command.Parameters.Add("@Type", SqlDbType.Int).Value = invoice.Type;
                        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = invoice.CustomerID;
                        command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = invoice.CustomerName;
                        command.Parameters.Add("@CustomerNo", SqlDbType.VarChar).Value = invoice.CustomerNo;
                        command.Parameters.Add("@CustomerAddress1", SqlDbType.VarChar).Value = invoice.CustomerAddress1;
                        command.Parameters.Add("@CustomerZipCode", SqlDbType.VarChar).Value = invoice.CustomerZipCode;
                        command.Parameters.Add("@CustomerCity", SqlDbType.VarChar).Value = invoice.CustomerCity;
                        command.Parameters.Add("@CustomerState", SqlDbType.VarChar).Value = invoice.CustomerState;
                        command.Parameters.Add("@CustomerCountry", SqlDbType.VarChar).Value = invoice.CustomerCountry;
                        command.Parameters.Add("@PaymentTermID", SqlDbType.Int).Value = invoice.PaymentTermID;

                        if (invoice.PaymentTermText == null)
                            command.Parameters.Add("@PaymentTermText", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@PaymentTermText", SqlDbType.VarChar).Value = invoice.PaymentTermText;

                        command.Parameters.Add("@CurrencyAbb", SqlDbType.VarChar).Value = invoice.CurrencyAbb;
                        command.Parameters.Add("@CurrencyRate", SqlDbType.Float).Value = invoice.CurrencyRate;
                        command.Parameters.Add("@DefaultVAT", SqlDbType.Float).Value = invoice.DefaultVAT;
                        command.Parameters.Add("@AddVAT", SqlDbType.Bit).Value = invoice.AddVAT;
                        command.Parameters.Add("@NetAmount", SqlDbType.Float).Value = invoice.NetAmount;
                        command.Parameters.Add("@NetAmountSystemCurrency", SqlDbType.Float).Value = invoice.NetAmountSystemCurrency;
                        command.Parameters.Add("@VATIncluded", SqlDbType.Float).Value = invoice.VATIncluded;
                        command.Parameters.Add("@VATIncludedSystemCurrency", SqlDbType.Float).Value = invoice.VATIncludedSystemCurrency;
                        if (invoice.ProjectNo == null)
                            command.Parameters.Add("@ProjectNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProjectNo", SqlDbType.VarChar).Value = invoice.ProjectNo;


                        if (invoice.PurchaseNo == null)
                            command.Parameters.Add("@PurchaseNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@PurchaseNo", SqlDbType.VarChar).Value = invoice.PurchaseNo;

                        if (invoice.ContactFullName == null)
                            command.Parameters.Add("@ContactFullName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ContactFullName", SqlDbType.VarChar).Value = invoice.ContactFullName;

                        command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = invoice.DepartmentID;

                        if (invoice.DepartmentTree == null)
                            command.Parameters.Add("@DepartmentTree", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@DepartmentTree", SqlDbType.VarChar).Value = invoice.DepartmentTree;

                        if (invoice.ExternalInvoiceNo == null)
                            command.Parameters.Add("@ExternalInvoiceNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ExternalInvoiceNo", SqlDbType.VarChar).Value = invoice.ExternalInvoiceNo;

                        if (invoice.CustomerReference == null)
                            command.Parameters.Add("@CustomerReference", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@CustomerReference", SqlDbType.VarChar).Value = invoice.CustomerReference;

                        if (invoice.ExternalInvoiceStatus == null)
                            command.Parameters.Add("@ExternalInvoiceStatus", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ExternalInvoiceStatus", SqlDbType.VarChar).Value = invoice.ExternalInvoiceStatus;

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into  Invoices table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SaveInvoiceLinesToDb(string table, DateTime? startDate, DateTime? endDate, List<InvoiceLine> invoiceLines)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table if items exist from those dates
                string sDate = ((DateTime)startDate).ToString("yyyy-MM-dd");
                string eDate = ((DateTime)endDate).ToString("yyyy-MM-dd");
                string deleteCommand = "DELETE FROM " + table + " WHERE Date BETWEEN '" + sDate + "' AND '" + eDate + "'";
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the InvoiceLines table");
                }

                //Insert invoice lines into db
                foreach (InvoiceLine invoiceLine in invoiceLines)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, InvoiceID, InvoiceNo, Date, Text, Quantity, "
                           + "Rate, RateSystemCurrency, Amount, AmountSystemCurrency, ProjectID, ProjectName, "
                           + "ProjectNo, VAT, Discount, UnitType, ProductNo)"
                           + " VALUES (@ID, @InvoiceID, @InvoiceNo, @Date, @Text, @Quantity, @Rate, @RateSystemCurrency,"
                           + " @Amount, @AmountSystemCurrency, @ProjectID, @ProjectName, @ProjectNo, @VAT, @Discount,"
                           + " @UnitType, @ProductNo)";
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = invoiceLine.ID;
                        command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceLine.InvoiceID;

                        if (invoiceLine.InvoiceNo == null)
                            command.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = invoiceLine.InvoiceNo;

                        command.Parameters.Add("@Date", SqlDbType.DateTime).Value = invoiceLine.Date;

                        if (invoiceLine.Text == null)
                            command.Parameters.Add("@Text", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Text", SqlDbType.VarChar).Value = invoiceLine.Text;

                        command.Parameters.Add("@Quantity", SqlDbType.Float).Value = invoiceLine.Quantity;
                        command.Parameters.Add("@Rate", SqlDbType.Float).Value = invoiceLine.Rate;
                        command.Parameters.Add("@RateSystemCurrency", SqlDbType.Float).Value = invoiceLine.RateSystemCurrency;
                        command.Parameters.Add("@Amount", SqlDbType.Float).Value = invoiceLine.Amount;
                        command.Parameters.Add("@AmountSystemCurrency", SqlDbType.Float).Value = invoiceLine.AmountSystemCurrency;
                        command.Parameters.Add("@ProjectID", SqlDbType.Int).Value = invoiceLine.ProjectID;

                        if (invoiceLine.ProjectName == null)
                            command.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProjectName", SqlDbType.VarChar).Value = invoiceLine.ProjectName;

                        if (invoiceLine.ProjectNo == null)
                            command.Parameters.Add("@ProjectNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProjectNo", SqlDbType.Int).Value = invoiceLine.ProjectNo;

                        command.Parameters.Add("@VAT", SqlDbType.Float).Value = invoiceLine.VAT;
                        command.Parameters.Add("@Discount", SqlDbType.Float).Value = invoiceLine.Discount;
                        command.Parameters.Add("@UnitType", SqlDbType.Int).Value = invoiceLine.UnitType;

                        if (invoiceLine.ProductNo == null)
                            command.Parameters.Add("@ProductNo", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ProductNo", SqlDbType.VarChar).Value = invoiceLine.ProductNo;

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into InvoiceLines table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SaveEmployeesToDb(string table,  List<Employee> employees)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table if items exist from those dates
                string deleteCommand = "DELETE FROM " + table;
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the employees table");
                }

                //Insert invoice lines into db
                foreach (Employee employee in employees)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, FirstName, LastName, FullName, Initials, Title, "
                           + "Email, Phone, Mobile, PrivatePhone, Address, ZipCode, City, Status, HiredDate, "
                           + "TerminatedDate, DepartmentNameID, DepartmentName)"
                           + " VALUES (@ID, @FirstName, @LastName, @FullName, @Initials, @Title, @Email, @Phone,"
                           + " @Mobile, @PrivatePhone, @Address, @ZipCode, @City, @Status, @HiredDate, @TerminatedDate,"
                           + " @DepartmentNameID, @DepartmentName)";
         
                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = employee.ID;

                        if (employee.FirstName == null)
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = employee.FirstName;

                        if (employee.LastName == null)
                            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = employee.LastName;

                        if (employee.FullName == null)
                            command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = employee.FullName;

                        if (employee.Initials == null)
                            command.Parameters.Add("@Initials", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Initials", SqlDbType.VarChar).Value = employee.Initials;

                        if (employee.Title == null)
                            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = employee.Title;

                        if (employee.Email == null)
                            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;


                        if (employee.Phone == null)
                            command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;

                        if (employee.Mobile == null)
                            command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = employee.Mobile;

                        if (employee.PrivatePhone == null)
                            command.Parameters.Add("@PrivatePhone", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@PrivatePhone", SqlDbType.VarChar).Value = employee.PrivatePhone;

                        if (employee.Address == null)
                            command.Parameters.Add("@Address", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Address", SqlDbType.VarChar).Value = employee.Address;

                        if (employee.ZipCode == null)
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = employee.ZipCode;

                        if (employee.City == null)
                            command.Parameters.Add("@City", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@City", SqlDbType.VarChar).Value = employee.City;
                       
                        command.Parameters.Add("@Status", SqlDbType.Int).Value = employee.Status;

                        if (employee.HiredDate == DateTime.MinValue)
                            command.Parameters.Add("@HiredDate", SqlDbType.DateTime).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@HiredDate", SqlDbType.DateTime).Value = employee.HiredDate;

                        if (employee.TerminatedDate == DateTime.MinValue)
                            command.Parameters.Add("@TerminatedDate", SqlDbType.DateTime).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@TerminatedDate", SqlDbType.DateTime).Value = employee.TerminatedDate;

                        command.Parameters.Add("@DepartmentNameID", SqlDbType.Int).Value = employee.DepartmentNameID;

                        if (employee.DepartmentName == null)
                            command.Parameters.Add("@DepartmentName", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@DepartmentName", SqlDbType.VarChar).Value = employee.DepartmentName;

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into employees table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SaveDepartmentsToDb(string table, List<Department> departments)
        {
            SqlConnection cnn;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["TimelogDb"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                //First clean table if items exist from those dates
                string deleteCommand = "DELETE FROM " + table;
                using (SqlCommand command = new SqlCommand(deleteCommand, cnn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Cleaned the departments table");
                }

                //Insert invoice lines into db
                foreach (Department department in departments)
                {
                    string sqlCommand = "INSERT INTO " + table + " (ID, Name, ParentID)"
                           + " VALUES (@ID, @Name, @ParentID)";

                    using (SqlCommand command = new SqlCommand(sqlCommand, cnn))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = department.ID;

                        if (department.Name == null)
                            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = DBNull.Value;
                        else
                            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = department.Name;

                        command.Parameters.Add("@ParentID", SqlDbType.Int).Value = department.ParentID;
                       
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Inserted data into departments table");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
