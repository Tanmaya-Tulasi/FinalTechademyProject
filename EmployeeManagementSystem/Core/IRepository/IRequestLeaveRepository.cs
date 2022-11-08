using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
    public interface IRequestLeaveRepository
    {
        public Task<List<RequestLeave>> GetAllLeaves();
        public Task<RequestLeave> GetLeave(int LeaveID);
        public Task<RequestLeave> AddLeave(RequestLeave requestLeave);
        public Task<RequestLeave> UpdateLeave(int LeaveID, RequestLeave requestLeave);
        public Task<RequestLeave> DeleteLeave(int LeaveID);
        void Save();
    }
}
