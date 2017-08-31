using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class Project
    {
        private int id;
        private string name;
        private string no;
        private Byte status;
        private int customerID;
        private string customerName;
        private string customerNo;
        private int pmid;
        private string pmInitials;
        private string pmFullName;
        private int projectTypeID;
        private string projectTypeName;
        private int projectCategoryID;
        private string projectCategoryName;
        private float budgetAmountFixedPriceTasks;
        private float budgetAmountFixedPriceProject;
        private float budgetAmountTimeAndMaterial;
        private float budgetAmountExpenses;
        private float budgetAmountTravel;
        private float budgetHoursFixedPriceTasks;
        private float budgetHoursFixedPriceProject;
        private float budgetHoursTimeAndMaterial;

        public Project(){ }

        public Project(int id, string name, string no, byte status, int customerID, string customerName, string customerNo, int pmid, string pmInitials, string pmFullName, int projectTypeID, string projectTypeName, int projectCategoryID, string projectCategoryName, float budgetAmountFixedPriceTasks, float budgetAmountFixedPriceProject, float budgetAmountTimeAndMaterial, float budgetAmountExpenses, float budgetAmountTravel, float budgetHoursFixedPriceTasks, float budgetHoursFixedPriceProject, float budgetHoursTimeAndMaterial)
        {
            this.id = id;
            this.name = name;
            this.no = no;
            this.status = status;
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerNo = customerNo;
            this.pmid = pmid;
            this.pmInitials = pmInitials;
            this.pmFullName = pmFullName;
            this.projectTypeID = projectTypeID;
            this.projectTypeName = projectTypeName;
            this.projectCategoryID = projectCategoryID;
            this.projectCategoryName = projectCategoryName;
            this.budgetAmountFixedPriceTasks = budgetAmountFixedPriceTasks;
            this.budgetAmountFixedPriceProject = budgetAmountFixedPriceProject;
            this.budgetAmountTimeAndMaterial = budgetAmountTimeAndMaterial;
            this.budgetAmountExpenses = budgetAmountExpenses;
            this.budgetAmountTravel = budgetAmountTravel;
            this.budgetHoursFixedPriceTasks = budgetHoursFixedPriceTasks;
            this.budgetHoursFixedPriceProject = budgetHoursFixedPriceProject;
            this.budgetHoursTimeAndMaterial = budgetHoursTimeAndMaterial;
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public byte Status
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

        public int PMID
        {
            get
            {
                return pmid;
            }

            set
            {
                pmid = value;
            }
        }

        public string PMInitials
        {
            get
            {
                return pmInitials;
            }

            set
            {
                pmInitials = value;
            }
        }

        public string PMFullName
        {
            get
            {
                return pmFullName;
            }

            set
            {
                pmFullName = value;
            }
        }

        public int ProjectTypeID
        {
            get
            {
                return projectTypeID;
            }

            set
            {
                projectTypeID = value;
            }
        }

        public string ProjectTypeName
        {
            get
            {
                return projectTypeName;
            }

            set
            {
                projectTypeName = value;
            }
        }

        public int ProjectCategoryID
        {
            get
            {
                return projectCategoryID;
            }

            set
            {
                projectCategoryID = value;
            }
        }

        public string ProjectCategoryName
        {
            get
            {
                return projectCategoryName;
            }

            set
            {
                projectCategoryName = value;
            }
        }

        public float BudgetAmountFixedPriceTasks
        {
            get
            {
                return budgetAmountFixedPriceTasks;
            }

            set
            {
                budgetAmountFixedPriceTasks = value;
            }
        }

        public float BudgetAmountFixedPriceProject
        {
            get
            {
                return budgetAmountFixedPriceProject;
            }

            set
            {
                budgetAmountFixedPriceProject = value;
            }
        }

        public float BudgetAmountTimeAndMaterial
        {
            get
            {
                return budgetAmountTimeAndMaterial;
            }

            set
            {
                budgetAmountTimeAndMaterial = value;
            }
        }

        public float BudgetAmountExpenses
        {
            get
            {
                return budgetAmountExpenses;
            }

            set
            {
                budgetAmountExpenses = value;
            }
        }

        public float BudgetAmountTravel
        {
            get
            {
                return budgetAmountTravel;
            }

            set
            {
                budgetAmountTravel = value;
            }
        }

        public float BudgetHoursFixedPriceTasks
        {
            get
            {
                return budgetHoursFixedPriceTasks;
            }

            set
            {
                budgetHoursFixedPriceTasks = value;
            }
        }

        public float BudgetHoursFixedPriceProject
        {
            get
            {
                return budgetHoursFixedPriceProject;
            }

            set
            {
                budgetHoursFixedPriceProject = value;
            }
        }

        public float BudgetHoursTimeAndMaterial
        {
            get
            {
                return budgetHoursTimeAndMaterial;
            }

            set
            {
                budgetHoursTimeAndMaterial = value;
            }
        }
    }
}
