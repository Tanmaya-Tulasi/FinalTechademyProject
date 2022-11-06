using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeDTO
    {
        [Key]
        public int ID { get; set; }
       // [Key,ForeignKey("EmployeeTable")]
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }

      //  [Key,ForeignKey("DesignationTable")]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
