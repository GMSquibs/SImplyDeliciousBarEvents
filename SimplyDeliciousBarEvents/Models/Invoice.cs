using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyDeliciousBarEvents.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int EventId {get;set;}
        public int MenuId { get; set; }

        public int Quantity { get; set; }
        public decimal CalculatedCost { get; set; }
    }
}
