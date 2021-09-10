using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EventModel
    {
        [Key]

        public int Id { get; set; }
        private DateTime _eventDate;
        private TimeSpan _eventTime;
        private LocationModel _eventLocation;
        private ClientModel _client;
        private List<EmployeeModel> _employeesWorkingEvent;
        private List<MenuModel> _eventMenu;
        private string _eventNotes;
        private decimal _eventCost;
        private int _headCount;

        public EventModel()
        {

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

        public LocationModel EventLocation
        {
            get { return _eventLocation; }
            set { _eventLocation = value; }
        }

        public ClientModel Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public List<MenuModel> EventMenu
        {
            get { return _eventMenu; }
            set { _eventMenu = value; }
        }

        public List<EmployeeModel> EmployeesWorkingEvent
        {
            get { return _employeesWorkingEvent; }
            set { _employeesWorkingEvent = value; }
        }

        public string EventNotes
        {
            get { return _eventNotes; }
            set { _eventNotes = value; }
        }

        public decimal EventCost
        {
            get { return _eventCost; }
            set { _eventCost = value; }
        }

        public int HeadCount
        {
            get { return _headCount; }
            set { _headCount = value; }
        }
    }
}
