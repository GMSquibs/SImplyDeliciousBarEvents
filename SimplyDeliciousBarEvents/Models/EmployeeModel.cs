using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        private string _employeeFirstName;
        private string _employeeLastName;
        private string _employeeContactNumber;

        public EmployeeModel()
        {

        }

        public string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; }
        }

        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; }
        }

        public string EmployeeContactNumber
        {
            get { return _employeeContactNumber; }
            set { _employeeContactNumber = value; }
        }
    }
}
