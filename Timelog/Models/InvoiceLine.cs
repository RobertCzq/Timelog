using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class InvoiceLine
    {
        private int id;
        private int invoiceID;
        private string invoiceNo;
        private DateTime date;
        private string text;
        private float quantity;
        private float rate;
        private float rateSystemCurrency;
        private float amount;
        private float amountSystemCurrency;
        private int projectID;
        private string projectName;
        private string projectNo;
        private float vat;
        private float discount;
        private int unitType;
        private string productNo;


        public InvoiceLine() { }

        public InvoiceLine(int id, int invoiceID, string invoiceNo, DateTime date, string text, float quantity, float rate, float rateSystemCurrency, float amount, float amountSystemCurrency, int projectID, string projectName, string projectNo, float vat, float discount, int unitType, string productNo)
        {
            this.id = id;
            this.invoiceID = invoiceID;
            this.invoiceNo = invoiceNo;
            this.date = date;
            this.text = text;
            this.quantity = quantity;
            this.rate = rate;
            this.rateSystemCurrency = rateSystemCurrency;
            this.amount = amount;
            this.amountSystemCurrency = amountSystemCurrency;
            this.projectID = projectID;
            this.projectName = projectName;
            this.projectNo = projectNo;
            this.vat = vat;
            this.discount = discount;
            this.unitType = unitType;
            this.productNo = productNo;
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

        public int InvoiceID
        {
            get
            {
                return invoiceID;
            }

            set
            {
                invoiceID = value;
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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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

        public float Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public float Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public float RateSystemCurrency
        {
            get
            {
                return rateSystemCurrency;
            }

            set
            {
                rateSystemCurrency = value;
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

        public float AmountSystemCurrency
        {
            get
            {
                return amountSystemCurrency;
            }

            set
            {
                amountSystemCurrency = value;
            }
        }

        public int ProjectID
        {
            get
            {
                return projectID;
            }

            set
            {
                projectID = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return projectName;
            }

            set
            {
                projectName = value;
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

        public float VAT
        {
            get
            {
                return vat;
            }

            set
            {
                vat = value;
            }
        }

        public float Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public int UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }

        public string ProductNo
        {
            get
            {
                return productNo;
            }

            set
            {
                productNo = value;
            }
        }
    }
}
