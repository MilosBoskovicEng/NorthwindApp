using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ICustomerCustomerDemo
    {
        List<CustomerCustomerDemo> getAllCustomerCustomerDemo();
        CustomerCustomerDemo getCustomerCustomerDemoById(string customerID, string CustomerTypeID);
        int addCustomerCustomerDemo(CustomerCustomerDemo customerCustomerDemo);
        int deleteCustomerCustomerDemo(string customerID, string CustomerTypeID);
    }
}
