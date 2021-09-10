using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SimplyDeliciousBarEvents.Data;

namespace SimplyDeliciousBarEvents.Models
{
    public class LocationModel
    { 
        [Key]

        public int Id { get; set; }

        private string _locationName;
        private string _locationOwnerFirstName;
        private string _locationOwnerLastName;
        private string _locationContactNumber;
        private AddressModel _locationAddress;
        private DataTable _locations;
        public LocationModel(string locationName, string locationOwnerFirstName, string locationOwnerLastName,
            string locationContactNumber, AddressModel locationAddress)
        {
            LocationName = locationName;
            LocationOwnerFirstName = locationOwnerFirstName;
            LocationOwnerLastName = locationOwnerLastName;
            LocationContactNumber = locationContactNumber;
            LocationAddress = locationAddress;
        }

        public LocationModel()
        {
            
        }

        public bool IsAuthorized()
        {
            //TODO Add in authorization logic
            return true;
        }
        

        public string LocationName
        {
            get { return _locationName; }
            set
            {
                _locationName = value;
            }
        }

        public string LocationOwnerFirstName
        {
            get { return _locationOwnerFirstName; }
            set
            {
                _locationOwnerFirstName = value;
            }
        }

        public string LocationOwnerLastName
        {
            get { return _locationOwnerLastName; }
            set { _locationOwnerLastName = value; }
        }

        public string LocationContactNumber
        {
            get { return _locationContactNumber; }
            set { _locationContactNumber = value; }
        }

        public AddressModel LocationAddress
        {
            get { return _locationAddress; }
            set { _locationAddress = value; }
        }
        

        public void UpdateLocation()
        {

        }

        public void DeleteLocation()
        {

        }

        public void CreateLocation()
        {

            using (DatabaseAccess createNewLocation = new DatabaseAccess())
            {
                createNewLocation.CreateLocation
                    (
                     this.LocationName,
                     this.LocationOwnerFirstName,
                     this.LocationOwnerLastName,
                     this.LocationContactNumber,
                     "Address1",
                     "Address2",
                     "City",
                     "State",
                     "ZipCode"
                     );
            }
        }
    }
}
