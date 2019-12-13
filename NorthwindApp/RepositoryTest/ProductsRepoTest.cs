using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesService;
using Model;
using System.Collections.Generic;
using static Model.Products;

namespace RepositoryTest
{
    [TestClass]
    public class ProductsRepoTest
    {
        ProductsRepository repo = new ProductsRepository();
        static int index = 0;

        [TestMethod]
        public void getAllProducts()
        {
            List<Products> productsList = repo.getAllProducts();
            int contains = productsList.Count;
            Assert.IsTrue(contains == 77);
        }

        [TestMethod]
        public void getOrderDetailsById()
        {
            Products product = repo.getProductById(77);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void addProduct()
        {          
            Products product = new ProductsBuilder("sdsdsa", false).Build();
            index = repo.addProduct(product);
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateProduct()
        {
            Products product = repo.getProductById(index);
            int res = repo.updateProduct(product);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteProduct()
        {
            int res = repo.deleteProduct(index);
            Assert.IsTrue(res == 0);
        }
    }
}
