using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrders
    {
        List<Orders> getAllOrders();
        Orders getOrdersById(int orderID);
        int addOrders(Orders order);
        int updateOrders(Orders order);
        int deleteOrders(int orderID);
    }
}
