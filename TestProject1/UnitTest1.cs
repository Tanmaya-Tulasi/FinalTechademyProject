using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ReturnNotFound()
        {
            //var repository = new Mock<IEmployeeRepository>();
            //var controller = new EmployeeController(repository.Object);

            //var action = controller.GetEmployeeById(999);
            var emp = new EmployeeController();
            var ne =  emp.GetEmployeeById(1);

            Assert.IsInstanceOfType(ne, typeof(NotFoundResult));
        }
        [TestMethod]
        public void ReturnOnDelete()
        {
            var emp = new EmployeeRepository();
            var e = emp.DeleteEmployee(1);

            Assert.AreEqual(e, "Deleted Successfully");

            Assert.IsInstanceOfType(e, typeof(Task<EmployeeModel>));

            
        }
        [TestMethod]
        public void ReturnById()
        {
            var emp = new EmployeeController();
            var emp1 = new EmployeeRepository();
            var e = emp.GetEmployeeById(999);
            //Assert.IsNull(emp1.GetById(1008));

            Assert.IsInstanceOfType(e, typeof(Task<NotFoundResult>));
        }

    }
}
