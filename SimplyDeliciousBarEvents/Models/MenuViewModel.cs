using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class MenuViewModel
    {
        [Key]
        public int MenuID {get;set;}

        private string _beverageName;
        private float _price;
        private int _servings;

        public MenuViewModel()
        {

        }

        public string BeverageName
        {
            get { return _beverageName; }
            set { _beverageName = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Servings
        {
            get { return _servings; }
            set { _servings = value; }
        }
            
        
    }
}
