using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class Tour_Operator
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string patronymic { get; set; }
        public string passportNumber { get; set; }

        public Tour_Operator(string lastName, string firstName, string patronymic, string passportNumber)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.passportNumber = passportNumber;
        }
    }
}
