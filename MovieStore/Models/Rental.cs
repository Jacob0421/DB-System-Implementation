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
        public Transaction Transaction { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public Decimal RentalPrice { get; set; }
        public bool IsLate { get; set; }
        public int DaysLate { get; set; }
    }
}
