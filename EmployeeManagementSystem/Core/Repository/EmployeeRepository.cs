using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeRepository(EmployeeManagementDbContext _dbContext)
        {
            _context = _dbContext;
        }
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployee()
        {
            var employee = await _context.Employee
                .Join(
                _context.Designation,
                emp => emp.DesignationID,
                des => des.DesignationID,
                (emp, des) => new EmployeeDTO
                {
                    ID = emp.ID,
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = emp.EmployeeName,
                    Gender = emp.Gender,
                    PhoneNumber = emp.PhoneNumber,
                    Address = emp.Address,
                    Email = emp.Email,
                    DesignationID = des.DesignationID,
                    DesignationName = des.DesignationName,
                    RoleName = des.RoleName,
                    DepartmentName = des.DepartmentName,
                    MemberSince = emp.MemberSince

                }
                ).ToListAsync();
            return employee;
        }
    }
}
