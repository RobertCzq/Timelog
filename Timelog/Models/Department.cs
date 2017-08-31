using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class Department
    {
        private int id;
        private string name;
        private int parentID;


        public Department() { }
        public Department(int id, string name, int parentID)
        {
            this.id = id;
            this.name = name;
            this.parentID = parentID;
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

        public int ParentID
        {
            get
            {
                return parentID;
            }

            set
            {
                parentID = value;
            }
        }
    }
}
