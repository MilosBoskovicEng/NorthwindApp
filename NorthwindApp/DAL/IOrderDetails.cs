using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDetails
    {
        List<OrderDetails> getAllOrderDetails();
        OrderDetails getOrderDetailsById(int orderID, int productID);
        int addOrderDetails(OrderDetails orderDetails);
        int updateOrderDetails(OrderDetails orderDetails);
        int deleteOrderDetails(int orderID, int productID);
    }
}
