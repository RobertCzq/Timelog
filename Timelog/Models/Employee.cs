using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelog.Models
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private string fullName;
        private string initials;
        private string title;
        private string email;
        private string phone;
        private string mobile;
        private string privatePhone;
        private string address;
        private string zipCode;
        private string city;
        private int status;
        private DateTime hiredDate;
        private DateTime terminatedDate;
        private int departmentNameID;
        private string departmentName;

        public Employee() { }

        public Employee(int id, string firstName, string lastName, string fullName, string initials, string title, string email, string phone, string mobile, string privatePhone, string address, string zipCode, string city, int status, DateTime hiredDate, DateTime terminatedDate, int departmentNameID, string departmentName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = fullName;
            this.initials = initials;
            this.title = title;
            this.email = email;
            this.phone = phone;
            this.mobile = mobile;
            this.privatePhone = privatePhone;
            this.address = address;
            this.zipCode = zipCode;
            this.city = city;
            this.status = status;
            this.hiredDate = hiredDate;
            this.terminatedDate = terminatedDate;
            this.departmentNameID = departmentNameID;
            this.departmentName = departmentName;
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

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string Initials
        {
            get
            {
                return initials;
            }

            set
            {
                initials = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }

        public string PrivatePhone
        {
            get
            {
                return privatePhone;
            }

            set
            {
                privatePhone = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
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

        public DateTime HiredDate
        {
            get
            {
                return hiredDate;
            }

            set
            {
                hiredDate = value;
            }
        }

        public DateTime TerminatedDate
        {
            get
            {
                return terminatedDate;
            }

            set
            {
                terminatedDate = value;
            }
        }

        public int DepartmentNameID
        {
            get
            {
                return departmentNameID;
            }

            set
            {
                departmentNameID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }

            set
            {
                departmentName = value;
            }
        }
    }
}
