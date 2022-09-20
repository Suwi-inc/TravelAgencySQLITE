using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class Tourist
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string patronymic { get; set; }
        public string passportNumber { get; set; }
        public DateOnly birthDate
        {
            get; set;
        }

        public Tourist(string lastName, string firstName, string patronymic, string passportNumber, DateOnly birthDate)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.passportNumber = passportNumber;
            this.birthDate = birthDate;
        }
        override
        public string ToString()
        {
            return(
                "First Name :" + this.firstName
                + "\n" + "Middle Name :" + this.patronymic
                + "\n" + "Last Name :" + this.lastName
                + "\n" + "PassPort Number :" + this.passportNumber
                + "\n" + "Date of birth :" + this.birthDate + "\n" );
        }

        
    }
}
