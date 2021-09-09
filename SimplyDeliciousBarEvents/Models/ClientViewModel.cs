using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class ClientViewModel
    {
        [Key]
        public int ClientID { get; set; }

        private string _contactNumber;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private int _primaryOrSecondaryContact;

        public ClientViewModel()
        {

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

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int PrimaryOrSecondaryContact
        {
            get { return _primaryOrSecondaryContact; }
            set { _primaryOrSecondaryContact = value; }
        }
    }
}
