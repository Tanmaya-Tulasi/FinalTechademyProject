using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<DesignationModel> Designation { get; set; }
        public DbSet<EmployeeDTO> EmployeeDTO { get; set; }
        public DbSet<RegisterModel> Register { get; set; }
        public DbSet<WorkingHourModel> WorkingHours { get; set; }
        public DbSet<RequestLeave> RequestLeave { get; set; }
        public DbSet<PaymentRulesModel> PaymentRules { get; set; }
     }
}
