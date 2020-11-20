using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class TransactionDetails
    {
        [Key]
        public int TransactionDetailsId { get; set; }
        public Transaction MainTransaction { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode {get; set;}
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
