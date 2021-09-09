using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EventViewModel
    {
        [Key]
        public int EventID { get; set; }

        //private string _location;
        private DateTime _eventDate;
        private TimeSpan _eventTime;
        private int _headCount;
        private float _eventCost;
        private List<MenuViewModel> _menu;
        private ClientViewModel _client;
        private List<EmployeeViewModel> _employees;

        public EventViewModel()
        {

        }

        //public string Location
        //{
        //    get { return _location; }
        //    set { _location = value; }
        //}

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

        public List<EmployeeViewModel> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public ClientViewModel Client
        {
            get { return _client; }
            set { _client = value; }
        }

    }
}
