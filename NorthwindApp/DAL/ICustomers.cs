using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ICustomers
    {
        List<Customers> getAllCustomers();
        Customers getCustomerById(string customerID);
        string addCustomers(Customers customer);
        string updateCustomers(Customers customer);
        int deleteCustomers(string customerID);
        Customers findCustomerByNameAndPassword(string username, string password);
    }
}
