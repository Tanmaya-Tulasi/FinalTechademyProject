using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
    public interface IWorkingHourRepository
    {
        public Task<List<WorkingHourModel>> GetWorkingHours();
        public Task<WorkingHourModel> GetWorkingHoursById(int id);
        public Task<WorkingHourModel> AddHours(WorkingHourModel hours);

        public Task<WorkingHourModel> UpdateWorkingHours(int ID, WorkingHourModel workingHours);

        public Task<WorkingHourModel> DeleteHours(int id);

    }
}
