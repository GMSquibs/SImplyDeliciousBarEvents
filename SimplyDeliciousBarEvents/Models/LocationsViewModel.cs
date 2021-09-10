using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class LocationsViewModel
    {
        [Key]
        public int LocationID { get; set; }

        private string _locationName;
        private string _mainContact;
        private string _contactNumber;
        private string _city;
        private string _state;
        private int _zipCode;

        List<string> locations = new List<string>()
        {
            "Haseltine Estate", 
            "SparrowLane",
            "Sycamore Creek", 
            "Dooleys Chapel",
            "Diamond Room"
        };
        public LocationsViewModel(string locationName, string mainContact, string contactNumber, string city, string state, int zipCode)
        {
            LocationName = locationName;
            MainContact = mainContact;
            ContactNumber = contactNumber;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public LocationsViewModel(string locationName)
        {
            LocationName = locationName;            
        }

        public LocationsViewModel()
        {

        }

        public string LocationName 
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        public string MainContact
        {
            get { return _mainContact; }
            set { _mainContact = value; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
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

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        
    }
}
