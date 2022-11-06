using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
    public interface IDesignationRepository
    {
        public Task<List<DesignationModel>> GetDesignations();
        public  Task<DesignationModel> GetDesignationById(int Id);

        public Task<DesignationModel> AddDesignation(DesignationModel designation);
        public Task<DesignationModel> UpdateDesignation(int id, DesignationModel desig);
        public Task<DesignationModel> DeleteDesignation(int id);


    }
}
