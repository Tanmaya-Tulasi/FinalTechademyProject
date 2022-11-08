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
    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly EmployeeManagementDbContext dbcontext;

        public WorkingHourRepository(EmployeeManagementDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<WorkingHourModel>> GetWorkingHours()
        {
            try
            {
                var wh = await dbcontext.WorkingHours.ToListAsync();
                return wh;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<WorkingHourModel> GetWorkingHoursById(int id)
        {
            try
            {

                var wh = await dbcontext.WorkingHours.FirstOrDefaultAsync(d => d.HoursID == id);
                if(wh!= null)
                    return wh;
                throw new Exception();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<WorkingHourModel> AddHours(WorkingHourModel hours)
        {
            try
            {
                var result = await dbcontext.WorkingHours.AddAsync(hours);
                await dbcontext.SaveChangesAsync();
                //  var emp = _context.Employee.Find(employee.ID);
                return result.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<WorkingHourModel> UpdateWorkingHours(int ID, WorkingHourModel workingHours)
        {
            try
            {
                var result = await dbcontext.WorkingHours
                    .FirstOrDefaultAsync(w => w.HoursID == workingHours.HoursID);
                if (result != null)
                {
                    result.EmployeeID = workingHours.EmployeeID;
                    result.CompanyWokingHours = workingHours.CompanyWokingHours;
                    result.EmployeeWorkingHours = workingHours.EmployeeWorkingHours;
                    await dbcontext.SaveChangesAsync();
                    return result;
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<WorkingHourModel> DeleteHours(int id)
        {
            try
            {
                var hours = await dbcontext.WorkingHours.FindAsync(id);
                if(hours == null)
                   throw new Exception();
                var result = dbcontext.WorkingHours.Remove(hours);
                await dbcontext.SaveChangesAsync();
                return hours;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
