using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class InvoiceLineDetail
    {
        private int id;
        private int invoiceLineID;
        private int invoiceID;
        private DateTime registrationDate;
        private string text;
        private float units;
        private float rate;
        private float amount;
        private float originalUnits;
        private float originalRate;
        private float originalAmount;
        private int registrationType;
        private int originalType;
        private string employeeInitials;
        private int taskID;
        private string taskName;
        private float quantity;
        private float rateSystemCurrency;
        private float amountSystemCurrency;
        private float registeredQuantity;
        private float registeredRateSystemCurrency;
        private float registeredAmountSystemCurrency;
        private int registrationID;
        private int unitType;

        public InvoiceLineDetail() { }

        public InvoiceLineDetail(int id, int invoiceLineID, int invoiceID, DateTime registrationDate, string text, float units, float rate, float amount, float originalUnits, float originalRate, float originalAmount, int registrationType, int originalType, string employeeInitials, int taskID, string taskName, float quantity, float rateSystemCurrency, float amountSystemCurrency, float registeredQuantity, float registeredRateSystemCurrency, float registeredAmountSystemCurrency, int registrationID, int unitType)
        {
            this.id = id;
            this.invoiceLineID = invoiceLineID;
            this.invoiceID = invoiceID;
            this.registrationDate = registrationDate;
            this.text = text;
            this.units = units;
            this.rate = rate;
            this.amount = amount;
            this.originalUnits = originalUnits;
            this.originalRate = originalRate;
            this.originalAmount = originalAmount;
            this.registrationType = registrationType;
            this.originalType = originalType;
            this.employeeInitials = employeeInitials;
            this.taskID = taskID;
            this.taskName = taskName;
            this.quantity = quantity;
            this.rateSystemCurrency = rateSystemCurrency;
            this.amountSystemCurrency = amountSystemCurrency;
            this.registeredQuantity = registeredQuantity;
            this.registeredRateSystemCurrency = registeredRateSystemCurrency;
            this.registeredAmountSystemCurrency = registeredAmountSystemCurrency;
            this.registrationID = registrationID;
            this.unitType = unitType;
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

        public int InvoiceLineID
        {
            get
            {
                return invoiceLineID;
            }

            set
            {
                invoiceLineID = value;
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

        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                registrationDate = value;
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

        public float Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
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

        public float OriginalUnits
        {
            get
            {
                return originalUnits;
            }

            set
            {
                originalUnits = value;
            }
        }

        public float OriginalRate
        {
            get
            {
                return originalRate;
            }

            set
            {
                originalRate = value;
            }
        }

        public float OriginalAmount
        {
            get
            {
                return originalAmount;
            }

            set
            {
                originalAmount = value;
            }
        }

        public int RegistrationType
        {
            get
            {
                return registrationType;
            }

            set
            {
                registrationType = value;
            }
        }

        public int OriginalType
        {
            get
            {
                return originalType;
            }

            set
            {
                originalType = value;
            }
        }

        public string EmployeeInitials
        {
            get
            {
                return employeeInitials;
            }

            set
            {
                employeeInitials = value;
            }
        }

        public int TaskID
        {
            get
            {
                return taskID;
            }

            set
            {
                taskID = value;
            }
        }

        public string TaskName
        {
            get
            {
                return taskName;
            }

            set
            {
                taskName = value;
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

        public float RegisteredQuantity
        {
            get
            {
                return registeredQuantity;
            }

            set
            {
                registeredQuantity = value;
            }
        }

        public float RegisteredRateSystemCurrency
        {
            get
            {
                return registeredRateSystemCurrency;
            }

            set
            {
                registeredRateSystemCurrency = value;
            }
        }

        public float RegisteredAmountSystemCurrency
        {
            get
            {
                return registeredAmountSystemCurrency;
            }

            set
            {
                registeredAmountSystemCurrency = value;
            }
        }

        public int RegistrationID
        {
            get
            {
                return registrationID;
            }

            set
            {
                registrationID = value;
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
    }
}
