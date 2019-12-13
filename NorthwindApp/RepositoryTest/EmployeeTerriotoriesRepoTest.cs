using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using BussinesService;

namespace RepositoryTest
{
    [TestClass]
    public class EmployeeTerriotoriesRepoTest
    {

        EmployeeTerritoriesRepository repo = new EmployeeTerritoriesRepository();

        [TestMethod]
        public void getAllEmployeeTerritories()
        {
            List<EmployeeTerritories> list = repo.getAllEmployeeTerritories();
            int contains = list.Count;

            Assert.IsTrue(contains == 50);
        }

        [TestMethod]
        public void getEmployeeTerritoriesById()
        {
            EmployeeTerritories employeeTerritories = repo.getEmployeeTerritoriesById(1, "06897");
            Assert.IsNotNull(employeeTerritories);
        }

        [TestMethod]
        public void addEmployeeTerritories()
        {
            EmployeeTerritories employeeTerritories = new EmployeeTerritories(1, "01581");
            int res = repo.addEmployeeTerritories(employeeTerritories);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteEmployeeTerritories()
        {
            int res = repo.deleteEmployeeTerritories(1, "01581");
            Assert.IsTrue(res == 0);
        }
    }
}
