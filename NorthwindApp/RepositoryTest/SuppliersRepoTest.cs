using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using BussinesService;
using static Model.Suppliers;

namespace RepositoryTest
{
    [TestClass]
    public class SuppliersRepoTest
    {

        SuppliersRepository repo = new SuppliersRepository();
        static int index = 0;

        [TestMethod]
        public void getAllSuppliers()
        {
            List<Suppliers> suppliersList = repo.getAllSuppliers();
            int contains = suppliersList.Count;
            Assert.IsTrue(contains == 29);
        }

        [TestMethod]
        public void getSupplierById()
        {
            Suppliers supplier = repo.getSupplierById(29);
            Assert.IsNotNull(supplier);
        }

        [TestMethod]
        public void addSupplier()
        {      
            Suppliers supplier = new SuppliersBuilder("Moji Brodovi").Build();
            index = repo.addSupplier(supplier);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateSupplier()
        {
            Suppliers supplier = new SuppliersBuilder("Moji Brodovi").Build();
            int res = repo.updateSupplier(supplier);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteSupplier()
        {
            int res = repo.deleteSupplier(index);
            Assert.IsTrue(res == 0);
        }
    }
}
