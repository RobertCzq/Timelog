using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class Invoice
    {
        private int id;
        private string invoiceNo;
        private string header;
        private string text;
        private DateTime invoiceDate;
        private DateTime dueDate;
        private float amount;
        private int status;
        private int type;
        private int customerID;
        private string customerName;
        private string customerNo;
        private string customerAddress1;
        private string customerZipCode;
        private string customerCity;
        private string customerState;
        private string customerCountry;
        private int paymentTermID;
        private string paymentTermText;
        private string currencyAbb;
        private float currencyRate;
        private float defaultVAT;
        private byte addVAT;
        private float netAmount;
        private float netAmountSystemCurrency;
        private float vatIncluded;
        private float vatIncludedSystemCurrency;
        private string projectNo;
        private string purchaseNo;
        private string contactFullName;
        private int departmentID;
        private string departmentTree;
        private string externalInvoiceNo;
        private string customerReference;
        private string externalInvoiceStatus;

        public Invoice() { }

        public Invoice(int id, string invoiceNumber, string header, string text, DateTime invoiceDate, DateTime dueDate, float amount, int status, int type, int customerID, string customerName, string customerNo, string customerAddress1, string customerZipCode, string customerCity, string customerState, string customerCountry, int paymentTermID, string paymentTermText, string currencyAbb, float currencyRate, float defaultVAT, byte addVAT, float netAmount, float netAmountSystemCurrency, float vatIncluded, float vatIncludedSystemCurrency, string projectNo, string purchaseNo, string contactFullName, int departmentID, string departmentTree, string externalInvoiceNo, string customerReference, string externalInvoiceStatus)
        {
            this.id = id;
            this.invoiceNo = invoiceNumber;
            this.header = header;
            this.text = text;
            this.invoiceDate = invoiceDate;
            this.dueDate = dueDate;
            this.amount = amount;
            this.status = status;
            this.type = type;
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerNo = customerNo;
            this.customerAddress1 = customerAddress1;
            this.customerZipCode = customerZipCode;
            this.customerCity = customerCity;
            this.customerState = customerState;
            this.customerCountry = customerCountry;
            this.paymentTermID = paymentTermID;
            this.paymentTermText = paymentTermText;
            this.currencyAbb = currencyAbb;
            this.currencyRate = currencyRate;
            this.defaultVAT = defaultVAT;
            this.addVAT = addVAT;
            this.netAmount = netAmount;
            this.netAmountSystemCurrency = netAmountSystemCurrency;
            this.vatIncluded = vatIncluded;
            this.vatIncludedSystemCurrency = vatIncludedSystemCurrency;
            this.projectNo = projectNo;
            this.purchaseNo = purchaseNo;
            this.contactFullName = contactFullName;
            this.departmentID = departmentID;
            this.departmentTree = departmentTree;
            this.externalInvoiceNo = externalInvoiceNo;
            this.customerReference = customerReference;
            this.externalInvoiceStatus = externalInvoiceStatus;
        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string InvoiceNo
        {
            get
            {
                return invoiceNo;
            }

            set
            {
                invoiceNo = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return invoiceDate;
            }

            set
            {
                invoiceDate = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string CustomerNo
        {
            get
            {
                return customerNo;
            }

            set
            {
                customerNo = value;
            }
        }

        public string CustomerAddress1
        {
            get
            {
                return customerAddress1;
            }

            set
            {
                customerAddress1 = value;
            }
        }

        public string CustomerZipCode
        {
            get
            {
                return customerZipCode;
            }

            set
            {
                customerZipCode = value;
            }
        }

        public string CustomerCity
        {
            get
            {
                return customerCity;
            }

            set
            {
                customerCity = value;
            }
        }

        public string CustomerState
        {
            get
            {
                return customerState;
            }

            set
            {
                customerState = value;
            }
        }

        public string CustomerCountry
        {
            get
            {
                return customerCountry;
            }

            set
            {
                customerCountry = value;
            }
        }

        public int PaymentTermID
        {
            get
            {
                return paymentTermID;
            }

            set
            {
                paymentTermID = value;
            }
        }

        public string PaymentTermText
        {
            get
            {
                return paymentTermText;
            }

            set
            {
                paymentTermText = value;
            }
        }

        public string CurrencyAbb
        {
            get
            {
                return currencyAbb;
            }

            set
            {
                currencyAbb = value;
            }
        }

        public float CurrencyRate
        {
            get
            {
                return currencyRate;
            }

            set
            {
                currencyRate = value;
            }
        }

        public float DefaultVAT
        {
            get
            {
                return defaultVAT;
            }

            set
            {
                defaultVAT = value;
            }
        }

        public byte AddVAT
        {
            get
            {
                return addVAT;
            }

            set
            {
                addVAT = value;
            }
        }

        public float NetAmount
        {
            get
            {
                return netAmount;
            }

            set
            {
                netAmount = value;
            }
        }

        public float NetAmountSystemCurrency
        {
            get
            {
                return netAmountSystemCurrency;
            }

            set
            {
                netAmountSystemCurrency = value;
            }
        }

        public float VATIncluded
        {
            get
            {
                return vatIncluded;
            }

            set
            {
                vatIncluded = value;
            }
        }

        public float VATIncludedSystemCurrency
        {
            get
            {
                return vatIncludedSystemCurrency;
            }

            set
            {
                vatIncludedSystemCurrency = value;
            }
        }

        public string ProjectNo
        {
            get
            {
                return projectNo;
            }

            set
            {
                projectNo = value;
            }
        }

        public string PurchaseNo
        {
            get
            {
                return purchaseNo;
            }

            set
            {
                purchaseNo = value;
            }
        }

        public string ContactFullName
        {
            get
            {
                return contactFullName;
            }

            set
            {
                contactFullName = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return departmentID;
            }

            set
            {
                departmentID = value;
            }
        }

        public string DepartmentTree
        {
            get
            {
                return departmentTree;
            }

            set
            {
                departmentTree = value;
            }
        }

        public string ExternalInvoiceNo
        {
            get
            {
                return externalInvoiceNo;
            }

            set
            {
                externalInvoiceNo = value;
            }
        }

        public string CustomerReference
        {
            get
            {
                return customerReference;
            }

            set
            {
                customerReference = value;
            }
        }

        public string ExternalInvoiceStatus
        {
            get
            {
                return externalInvoiceStatus;
            }

            set
            {
                externalInvoiceStatus = value;
            }
        }
    }
}
