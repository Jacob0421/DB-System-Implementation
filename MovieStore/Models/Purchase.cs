﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public Transaction PurchaseTransaction { get; set; }
    }
}
