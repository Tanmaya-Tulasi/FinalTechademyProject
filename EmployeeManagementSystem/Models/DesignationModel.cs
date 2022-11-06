using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    [Table("Designation")]
    public class DesignationModel
    {
        [Key]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        
        public ICollection<EmployeeModel> EmployeDetails { get; set; }
    }
}
