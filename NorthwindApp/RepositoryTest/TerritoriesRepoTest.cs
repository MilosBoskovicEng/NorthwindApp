using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;

namespace RepositoryTest
{
    [TestClass]
    public class TerritoriesRepoTest
    {
        TerritoriesRepository repo = new TerritoriesRepository();
        static string index = null;

        [TestMethod]
        public void getAllTerritories()
        {
            List<Territories> territoriesList = repo.getAllTerritories();
            int contains = territoriesList.Count;
            Assert.IsTrue(contains == 53);
        }

        [TestMethod]
        public void getSupplierById()
        {
            Territories territory = repo.getTerritoryById("98104");
            Assert.IsNotNull(territory);
        }

        [TestMethod]
        public void addTerritory()
        {
            Territories territory = new Territories("98101", "neka teritorija",3);
            index = repo.addTerritory(territory);
            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void updateTerritory()
        {
            Territories territory = new Territories("98101", "neka teritorija", 3);
            string res = repo.updateTerritory(territory);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void deleteTerritory()
        {
            int res = repo.deleteTerritory("98101");
            Assert.IsTrue(res == 0);
        }
    }
}
