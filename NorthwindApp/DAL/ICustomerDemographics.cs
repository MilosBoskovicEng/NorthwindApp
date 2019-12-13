using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ICustomerDemographics
    {
        List<CustomerDemographics> getAllCustomerDemographics();
        CustomerDemographics getCustomerDemographicsById(string CustomerTypeID);
        string addCustomerDemographics(CustomerDemographics customerDemographics);
        string updateCustomerDemographics(CustomerDemographics customerDemographics);
        int deleteCustomerDemographics(string CustomerTypeID);
    }
}
