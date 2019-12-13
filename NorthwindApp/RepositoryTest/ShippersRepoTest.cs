using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class ShippersRepoTest
    {

        ShippersRepository repo = new ShippersRepository();
        static int index = 0;

        [TestMethod]
        public void getAllRegions()
        {
            List<Shippers> shippersList = repo.getAllShippers();
            int contains = shippersList.Count;
            Assert.IsTrue(contains == 3);
        }

        [TestMethod]
        public void getRegionById()
        {
            Shippers shipper = repo.getShipperById(3);
            Assert.IsNotNull(shipper);
        }

        [TestMethod]
        public void addRegion()
        {
            Shippers shipper = new Shippers("Brod");
            index = repo.addShippers(shipper);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateShippers()
        {
            Shippers shipper = new Shippers("Brod");
            int res = repo.updateShippers(shipper);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteShippers()
        {
            int res = repo.deleteShippers(index);
            Assert.IsTrue(res == 0);
        }
    }
}
