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
    
    public class PaymentRulesRepository :IPaymentRulesRepository
    {
        private readonly EmployeeManagementDbContext dbContext;

        public PaymentRulesRepository(EmployeeManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<PaymentRulesModel>> GetAllPaymentRules()
        {
            try
            {
                var rules = await dbContext.PaymentRules.ToListAsync();
                return rules;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<PaymentRulesModel> GetById(int id)
        {
            try
            {
                var result = await dbContext.PaymentRules.FirstOrDefaultAsync(p => p.PaymentID == id);
                if (result == null)
                    throw new Exception("Not Found");
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<PaymentRulesModel> AddPaymentRule(PaymentRulesModel rule)
        {
            try
            {
                var result = await dbContext.PaymentRules.AddAsync(rule);
                await dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<PaymentRulesModel> UpdateRules(int id,PaymentRulesModel updatedrule)
        {
            try
            {
                var result = await dbContext.PaymentRules.FirstOrDefaultAsync(t => t.PaymentID == id);
                if (result == null)
                    throw new Exception("Not Found");
                result.PaymentRule = updatedrule.PaymentRule;
                await dbContext.SaveChangesAsync();
                return result;

            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<PaymentRulesModel> DeleteRule(int id)
        {
            try
            {
                var result = await dbContext.PaymentRules.FirstOrDefaultAsync(t => t.PaymentID == id);
                if (result == null)
                    throw new Exception("Not Found");
                var rule = dbContext.Remove(result);
                await dbContext.SaveChangesAsync();
                return result;

            }
            catch
            {
                throw new Exception("Error in Delete Rule");
            }
        }
    }

}
