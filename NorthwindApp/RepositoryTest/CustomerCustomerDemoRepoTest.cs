using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class CustomerCustomerDemoRepoTest
    {
        CustomerCustomerDemoRepository repo = new CustomerCustomerDemoRepository();

        [TestMethod]
        public void getAllCustomerCustomerDemo()
        {
            List<CustomerCustomerDemo> list = repo.getAllCustomerCustomerDemo();
            int contains = list.Count;

            Assert.IsTrue(contains == 1);
        }

        [TestMethod]
        public void getCustomerCustomerDemoById()
        {
            CustomerCustomerDemo custCustDemo = repo.getCustomerCustomerDemoById("ALFKI", "Usuall");
            Assert.IsNotNull(custCustDemo);
        }

        //[TestMethod]
        //public void addCustomerCustomerDemo()
        //{
        //    CustomerCustomerDemo custCustDemo = new CustomerCustomerDemo();
        //    custCustDemo.CustomerID = "ANATR";
        //    custCustDemo.CustomerTypeID = "Ussual";
        //    int res = repo.addCustomerCustomerDemo(custCustDemo);
        //    Assert.IsTrue(res != 0);
        //}

        [TestMethod]
        public void deleteCustomerCustomerDemo()
        {
            int res = repo.deleteCustomerCustomerDemo("AlFKI", "");
            Assert.IsTrue(res == 0);
        }
    }
}
