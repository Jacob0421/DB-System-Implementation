using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Actor
    {
        [Key]
        public int ActorNum { get; set; }
        public string ActorFName { get; set; }
        public string ActorLName { get; set; }
    }
}
