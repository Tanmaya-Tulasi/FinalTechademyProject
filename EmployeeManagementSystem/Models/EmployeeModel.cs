using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public  int DesignationID { get; set; }
        public DesignationModel Designation { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
