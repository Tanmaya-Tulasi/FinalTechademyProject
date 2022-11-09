﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class PaymentRulesModel
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentRule { get; set; }
    }
}
