using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IProducts
    {
        List<Products> getAllProducts();
        Products getProductById(int productID);
        int addProduct(Products product);
        int updateProduct(Products product);
        int deleteProduct(int productID);
    }
}
