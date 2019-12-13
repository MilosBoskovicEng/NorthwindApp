using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class RegionRepoTest
    {

        RegionRepository repo = new RegionRepository();
        static int index = 0;

        [TestMethod]
        public void getAllRegions()
        {
            List<Region> productsList = repo.getAllRegions();
            int contains = productsList.Count;
            Assert.IsTrue(contains == 4);
        }

        [TestMethod]
        public void getRegionById()
        {
            Region product = repo.getRegionById(4);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void addRegion()
        {
            Region product = new Region("Srbija");
            index = repo.addRegion(product);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateRegion()
        {
            Region product = new Region(5, "Srbija");
            int res = repo.updateRegion(product);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteRegion()
        {
            int res = repo.deleteRegion(index);
            Assert.IsTrue(res == 0);
        }
    }
}
