using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Core.IRepository
{
    public interface IPaymentRulesRepository
    {
        public Task<List<PaymentRulesModel>> GetAllPaymentRules();
        public Task<PaymentRulesModel> GetById(int id);
        public Task<PaymentRulesModel> AddPaymentRule(PaymentRulesModel rule);
        public Task<PaymentRulesModel> UpdateRules(int id, PaymentRulesModel updatedrule);
        public Task<PaymentRulesModel> DeleteRule(int id);



    }
}
