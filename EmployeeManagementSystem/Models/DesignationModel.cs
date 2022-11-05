using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class DesignationModel
    {
        [Key]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        
        public virtual ICollection<EmployeeModel> EmployeDetails { get; set; }
    }
}
