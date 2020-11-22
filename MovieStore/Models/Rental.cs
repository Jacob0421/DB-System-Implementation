using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public Transaction RentalTransaction { get; set; }
        public bool IsLate { get; set; }
        public bool Returned { get; set; }
        public int DaysLate { get; set; }
        public string DueDate { get; set; }
        public decimal RentalFinalCost { get; set; }
    }
}
