using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;
using static Model.Customers;

namespace RepositoryTest
{
    [TestClass]
    public class CustomerRepoTest
    {

        CustomersRepository repo = new CustomersRepository();

        [TestMethod]
        public void getAllCustomers()
        {
            List<Customers> customersList = repo.getAllCustomers();
            int contains = customersList.Count;
            Assert.IsTrue(contains == 91);
        }

        [TestMethod]
        public void getCustomerById()
        {
            Customers customer = repo.getCustomerById("ALFKI");
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void addCustomers()
        {           
            Customers customer = new CustomersBuilder("MILBO", "MBM - Solutions").Build();
            string res = repo.addCustomers(customer);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void updateCustomers()
        {
            Customers customer = new CustomersBuilder("MILBO", "MBM - Solutions").Build();
            string res = repo.updateCustomers(customer);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void deleteCustomers()
        {
            int res = repo.deleteCustomers("MILBO");
            Assert.IsTrue(res == 0);
        }
    }
}
