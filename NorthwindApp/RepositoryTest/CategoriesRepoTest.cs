using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Model;
using BussinesService;
using static Model.Categories;

namespace RepositoryTest
{
    [TestClass]
    public class CategoriesRepoTest
    {
        CategoriesRepository repo = new CategoriesRepository();
        static int index = 0;

        [TestMethod]
        public void getAllCategories()
        {
            List<Categories> categoriesList = repo.getAllCategories();
            int contains = categoriesList.Count;
            Assert.IsTrue(contains == 8);
        }

        [TestMethod]
        public void getCategoryById()
        {
            Categories category = repo.getCategoryById(1);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void addCategory()
        {
            Categories category = new CategoriesBuilder("New Category").Build();
            index = repo.addCategory(category);            
            Assert.IsTrue(index != 0);
        }

        [TestMethod]
        public void updateCategory()
        {
            Categories category = repo.getCategoryById(index);
            category.CategoryName = "Category";
            int res = repo.updateCategory(category);
            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void deleteCategory()
        {
            int res = repo.deleteCategory(index);
            Assert.IsTrue(res == 0);
        }
    }
}
