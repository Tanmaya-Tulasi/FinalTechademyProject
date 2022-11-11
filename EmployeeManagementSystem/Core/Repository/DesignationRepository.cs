using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeManagementDbContext dbContext;

        public DesignationRepository(EmployeeManagementDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public DesignationRepository()
        {
        }

        public async Task<List<DesignationModel>> GetDesignations()
        {
            try
            {
                var result = await dbContext.Designation.Select(c => new DesignationModel
                {
                    DesignationID= c.DesignationID,
                    DesignationName = c.DesignationName,
                    RoleName =c.RoleName,
                    DepartmentName = c.DepartmentName
                }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
        public async Task<DesignationModel> GetDesignationById(int Id)
        {
            try
            {
                var result = await dbContext.Designation.FirstOrDefaultAsync(t => t.DesignationID == Id);
                if (result != null)
                    return result;
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<DesignationModel> AddDesignation( DesignationModel designation)
        {
            try
            {
                var result = await dbContext.Designation.AddAsync(designation);
                await dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<DesignationModel> UpdateDesignation( int id, DesignationModel desig)
        {
            try
            {
                var designation = await dbContext.Designation.FindAsync(id);
                if (designation == null)
                    throw new Exception();
                designation.DepartmentName = desig.DepartmentName;
                designation.DesignationName = desig.DesignationName;
                designation.RoleName = desig.RoleName;
                designation.EmployeDetails = desig.EmployeDetails;
                await dbContext.SaveChangesAsync();
                return designation;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public async Task<DesignationModel> DeleteDesignation( int id)
        {
            try
            {
                var result = await dbContext.Designation.FindAsync(id);
                if (result == null)
                    throw new Exception();
                dbContext.Designation.Remove(result);
                await dbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
               throw e;
            }
        }
    }
}
