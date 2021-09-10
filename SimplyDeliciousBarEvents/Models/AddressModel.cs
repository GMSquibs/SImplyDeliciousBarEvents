using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private string _zip;

        public AddressModel(string address1, string address2, string city, string state, string zip)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
        }

        public AddressModel()
        {

        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

    }
}
