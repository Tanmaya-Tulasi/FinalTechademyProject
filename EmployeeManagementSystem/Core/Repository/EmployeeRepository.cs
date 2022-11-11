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

        

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {


            //var empl=await _context.Employee.ToListAsync();
            //return empl;
            try
            {
                var employee =await _context.Employee
                    .Join(
                    _context.Designation,
                    emp => emp.DesignationID,
                    des => des.DesignationID,
                    (emp, des) => new EmployeeDTO
                    {
                        ID = emp.ID,
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
                await _context.SaveChangesAsync();
                //if (employee != null)
                    return employee;
                //throw new Exception();
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            try
            {
                var result =await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
              //  var emp = _context.Employee.Find(employee.ID);
                return result.Entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<EmployeeModel> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                    throw new Exception();
                var result=_context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<EmployeeModel> GetById(int id)
        {
            try
            {
                var result = await _context.Employee.FirstOrDefaultAsync(t => t.ID == id);
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<EmployeeModel> UpdateEmployee(int id,EmployeeModel employee)
        {
            var e = await _context.Employee.FirstOrDefaultAsync(t =>t.ID == id);
            try 
            {
                if (e != null)
                {
                    e.ID = employee.ID;
                    e.EmployeeName = employee.EmployeeName;
                    e.PhoneNumber = employee.PhoneNumber;
                    e.Address = employee.Address;
                    e.Email = employee.Email;
                    e.Gender = employee.Gender;
                    e.DesignationID = employee.DesignationID;
                    e.MemberSince = employee.MemberSince;
                    
                    await _context.SaveChangesAsync();
                    return e;
                }
                else
                    throw new Exception("id not found");
            }
            catch
            {
                throw new Exception() ;
            }
        }
    }
}
