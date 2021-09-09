using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EventSheetViewModel
    {
        [Key]
        public int EventSheetID { get; set; }

        private string _location;
        private DateTime _eventDate;
        private TimeSpan _eventTime;
        private int _headCount;
        private float _eventCost;
        private List<MenuViewModel> _menu;
        private string _client;
        private string _clientContactNumber;
        private string _employee;

        public EventSheetViewModel(string location, DateTime eventDate, TimeSpan eventTime, int headCount, 
            float eventCost, string client, string clientContactNumber,string employee            
            )
        {
            Location = location;
            EventDate = eventDate;
            EventTime = eventTime;
            HeadCount = headCount;
            EventCost = eventCost;            
            Client = client;
            ClientContactNumber = clientContactNumber;
            Employee = employee;
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public DateTime EventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }

        public TimeSpan EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }

        public int HeadCount
        {
            get { return _headCount; }
            set { _headCount = value; }
        }

        public float EventCost
        {
            get { return _eventCost; }
            set { _eventCost = value; }
        }

        public List<MenuViewModel> Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public string Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public string ClientContactNumber
        {
            get { return _clientContactNumber; }
            set { _clientContactNumber = value; }
        }
    }
}
