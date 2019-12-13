using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;
using static Model.Orders;

namespace RepositoryTest
{
    [TestClass]
    public class OrdersRepoTest
    {

        OrdersRepository repo = new OrdersRepository();
        static int index = 0;

        [TestMethod]
        public void getAllOrders()
        {
            List<Orders> ordersList = repo.getAllOrders();
            int contains = ordersList.Count;
            Assert.IsTrue(contains == 842);
        }

        [TestMethod]
        public void getOrderById()
        {
            Orders order = repo.getOrdersById(11077);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void addOrder()
        {           
            Orders order = new OrdersBuilder().CustomerID("FRANS").Build();
            index = repo.addOrders(order);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateOrder()
        {
            Orders order = repo.getOrdersById(index);
            int res = repo.updateOrders(order);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteOrder()
        {
            int res = repo.deleteOrders(index);
            Assert.IsTrue(res == 0);
        }
    }
}
