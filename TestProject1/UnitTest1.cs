//using EmployeeManagementSystem.Controllers;
//using EmployeeManagementSystem.Core.IRepository;
//using EmployeeManagementSystem.Core.Repository;
//using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ReturnNotFound()
        {

            var controller = new EmployeeRepository();
            var action = controller.GetById(999);
            var emp = new EmployeeRepository();
            var ne = emp.GetById(1);
            Assert.IsNotNull(ne);
            Assert.AreEqual(1,action.Id);
            Assert.IsInstanceOfType(action, typeof(Task<EmployeeModel>));
        }
        [TestMethod]
        public void ReturnOnDelete()
        {
            var emp = new EmployeeRepository();
            var e = emp.DeleteEmployee(1);

           // Assert.AreEqual(e, "Deleted Successfully");

            Assert.IsInstanceOfType(e, typeof(Task<EmployeeModel>));


        }
        [TestMethod]
        public void ReturnById()
        {
            var emp = new EmployeeController();
            var emp1 = new EmployeeRepository();
            var e = emp1.GetById(999);
            Console.WriteLine(e);
           Assert.IsInstanceOfType(e, typeof(Task<EmployeeModel>));
            var  u= emp1.DeleteEmployee(999);
            Assert.IsNotInstanceOfType(e,typeof(EmployeeModel));
        }

    }
}
