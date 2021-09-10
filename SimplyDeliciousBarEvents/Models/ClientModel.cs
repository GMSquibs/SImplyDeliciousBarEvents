using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class ClientModel
    {
        [Key]

        public int Id { get; set; }

        private string _firstName;
        private string _lastName;
        private string _contactNumber;
        private string _email;

        public ClientModel()
        {

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

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


    }
}
