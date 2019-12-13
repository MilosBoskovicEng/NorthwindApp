using BussinesService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class CustomerDemographicsRepoTest
    {

        CustomerDemographicsRepository repo = new CustomerDemographicsRepository();

        [TestMethod]
        public void getAllCustomerDemographics()
        {
            List<CustomerDemographics> categoriesList = repo.getAllCustomerDemographics();
            int contains = categoriesList.Count;
            Assert.IsTrue(contains == 1);
        }

        [TestMethod]
        public void getCustomerDemographicsById()
        {
            CustomerDemographics customerDemographics = repo.getCustomerDemographicsById("Usuall");
            Assert.IsNotNull(customerDemographics);
        }

        [TestMethod]
        public void addCustomerDemographics()
        {
            CustomerDemographics customerDemographics = new CustomerDemographics("Regulary");
            string res = repo.addCustomerDemographics(customerDemographics);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void updateCustomerDemographics()
        {
            CustomerDemographics customerDemographics = new CustomerDemographics("Regulary", "nesto drugo");
            string res = repo.updateCustomerDemographics(customerDemographics);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void deleteCustomerDemographics()
        {
            int res = repo.deleteCustomerDemographics("Regulary");
            Assert.IsTrue(res == 0);
        }
    }
}
