using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class WorkUnit
    {
        private int id;
        private int employeeID;
        private string employeeInitials;
        private string employeeFirstName;
        private string employeeLastName;
        private int allocationID;
        private int taskID;
        private int projectID;
        private DateTime date;
        private string note;
        private string additionalTextField;
        private float regHours;
        private float billable;
        private float invHours;
        private float costAmount;
        private float regAmount;
        private float invAmount;

        public WorkUnit() { }

        public WorkUnit(int iD, int employeeID, string employeeInitials, string employeeFirstName, string employeeLastName, int allocationID, int taskID, int projectID, DateTime date, string note, string addtionalTextField, float regHours, float billable, float invHours, float costAmount, float regAmount, float invAmount)
        {
            id = iD;
            this.EmployeeID = employeeID;
            this.EmployeeInitials = employeeInitials;
            this.EmployeeFirstName = employeeFirstName;
            this.EmployeeLastName = employeeLastName;
            this.AllocationID = allocationID;
            this.TaskID = taskID;
            this.ProjectID = projectID;
            this.Date = date;
            this.Note = note;
            this.AdditionalTextField = addtionalTextField;
            this.RegHours = regHours;
            this.Billable = billable;
            this.InvHours = invHours;
            this.CostAmount = costAmount;
            this.RegAmount = regAmount;
            this.InvAmount = invAmount;
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

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
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

        public string EmployeeFirstName
        {
            get
            {
                return employeeFirstName;
            }

            set
            {
                employeeFirstName = value;
            }
        }

        public string EmployeeLastName
        {
            get
            {
                return employeeLastName;
            }

            set
            {
                employeeLastName = value;
            }
        }

        public int AllocationID
        {
            get
            {
                return allocationID;
            }

            set
            {
                allocationID = value;
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

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public string AdditionalTextField
        {
            get
            {
                return additionalTextField;
            }

            set
            {
                additionalTextField = value;
            }
        }

        public float RegHours
        {
            get
            {
                return regHours;
            }

            set
            {
                regHours = value;
            }
        }

        public float Billable
        {
            get
            {
                return billable;
            }

            set
            {
                billable = value;
            }
        }

        public float InvHours
        {
            get
            {
                return invHours;
            }

            set
            {
                invHours = value;
            }
        }

        public float CostAmount
        {
            get
            {
                return costAmount;
            }

            set
            {
                costAmount = value;
            }
        }

        public float RegAmount
        {
            get
            {
                return regAmount;
            }

            set
            {
                regAmount = value;
            }
        }

        public float InvAmount
        {
            get
            {
                return invAmount;
            }

            set
            {
                invAmount = value;
            }
        }

        
    }
}
