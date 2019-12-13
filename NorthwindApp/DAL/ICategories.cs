using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategories
    {
        List<Categories> getAllCategories();
        Categories getCategoryById(int categoryID);
        int addCategory(Categories category);
        int updateCategory(Categories category);
        int deleteCategory(int categoryID);
    }
}
