using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using System.Collections.Generic;
using Model;

namespace RepositoryTest
{
    [TestClass]
    public class OrderDetailsRepoTest
    {

        OrderDetailsRepository repo = new OrderDetailsRepository();

        [TestMethod]
        public void getAllOrderDetails()
        {
            List<OrderDetails> orderDetailsList = repo.getAllOrderDetails();
            int contains = orderDetailsList.Count;
            Assert.IsTrue(contains == 2164);
        }

        [TestMethod]
        public void getOrderDetailsById()
        {
            OrderDetails orderDetails = repo.getOrderDetailsById(10625, 60);
            Assert.IsNotNull(orderDetails);
        }

        [TestMethod]
        public void addOrderDetails()
        {
            OrderDetails orderDetails = new OrderDetails(10620, 19, 12.0m, 1, 0.2f);
            int res = repo.addOrderDetails(orderDetails);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void updateOrderDetails()
        {
            OrderDetails orderDetails = new OrderDetails(10620, 19, 12.0m, 1, 0.2f);
            int res = repo.updateOrderDetails(orderDetails);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteOrderDetails()
        {
            int res = repo.deleteOrderDetails(10620, 19);
            Assert.IsTrue(res == 0);
        }
    }
}
