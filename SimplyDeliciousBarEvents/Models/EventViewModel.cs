using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class EventViewModel : EventSheetViewModel
    {
        private string _location;
        private DateTime _eventDate;
        private DateTime _eventTime;
        private int _headCount;
        private float _eventCost;
        private List<MenuViewModel> _menu;
        private ClientViewModel _client;

        public EventViewModel()
        {

        }

       
    }
}
