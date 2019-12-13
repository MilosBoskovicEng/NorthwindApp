using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;
using static Model.Employees;

namespace RepositoryTest
{
    [TestClass]
    public class EmployeeRepoTest
    {
        EmployeesRepository repo = new EmployeesRepository();
        static int index = 0;

        [TestMethod]
        public void getAllEmployees()
        {
            List<Employees> employeesList = repo.getAllEmployees();
            int contains = employeesList.Count;
            Assert.IsTrue(contains == 9);
        }

        [TestMethod]
        public void getEmployeeById()
        {
            Employees employee = repo.getEmployeeById(1);
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void addEmployee()
        {
            Employees employee = new EmployeeBuilder("Boskovic", "Milos").Build();
            index = repo.addEmployee(employee);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateEmployee()
        {
            Employees employee = repo.getEmployeeById(index);
            int res = repo.updateEmployee(employee);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteEmployee()
        {
            int res = repo.deleteEmployee(index);
            Assert.IsTrue(res == 0);
        }
    }
    }
