using EmployeeManagementSystem.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDesignation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetvyId()
        {
        }
        [TestMethod]
        public void GetAll()
        {
            var result = new DesignationRepository();
            var r =  result.GetDesignations();
            Assert.IsNotNull(r);
        }
    }
}
