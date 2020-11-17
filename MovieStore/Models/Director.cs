using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Director
    {
        [Key]
        public int DirectorNum { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
