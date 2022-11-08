using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class WorkingHourModel
    {
        [Key]
        public int HoursID { get; set; }
        public int EmployeeID { get; set; }

        public double CompanyWokingHours { get; set; }

        public double EmployeeWorkingHours { get; set; }
    }
}
