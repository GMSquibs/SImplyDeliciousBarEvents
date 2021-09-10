using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeID { get; set; }

        private string _contactNumber;
        private string _firstName;
        private string _lastName;                

        public EmployeeViewModel()
        {

        }

        public EmployeeViewModel(string firstName, string lastName, string contactNumber)
        {

        }

        public EmployeeViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
    }
}
