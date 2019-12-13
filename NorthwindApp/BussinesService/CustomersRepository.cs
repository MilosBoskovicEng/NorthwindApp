using DAL;
using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Customers;
using System.Data;
using InfrastucturedServices;

namespace BussinesService
{
    public class CustomersRepository : ICustomers
    {
        LoggerService logger = new LoggerService();

        public List<Customers> getAllCustomers()
        {
            List<Customers> customersList = new List<Customers>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Customers", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Customers customer = new CustomersBuilder(dataReader.GetString(0), dataReader.GetString(1))
                                                    .ContactName(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                    .ContactTitle(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                    .Address(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                    .City(dataReader.IsDBNull(5) ? (string)null : dataReader.GetString(5))
                                                    .Region(dataReader.IsDBNull(6) ? (string)null : dataReader.GetString(6))
                                                    .PostalCode(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                    .Country(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                    .Phone(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                    .Fax(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                    .Build();
                        customersList.Add(customer);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Customers.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllCustomers method has sucessfully invoked.");
                return customersList;
            }
        }

        public Customers getCustomerById(string customerID)
        {
            Customers customer = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetCustomerById";

            selectCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            selectCommand.Parameters["@CustomerID"].Value = customerID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        customer = new CustomersBuilder(dataReader.GetString(0), dataReader.GetString(1))
                                                    .ContactName(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                    .ContactTitle(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                    .Address(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                    .City(dataReader.IsDBNull(5) ? (string)null : dataReader.GetString(5))
                                                    .Region(dataReader.IsDBNull(6) ? (string)null : dataReader.GetString(6))
                                                    .PostalCode(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                    .Country(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                    .Phone(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                    .Fax(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                    .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Customer with CustomerID = " + customerID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetCustomerById method has sucessfully invoked.");
                return customer;
            }
        }

        public Customers findCustomerByNameAndPassword(string username, string password)
        {
            Customers customer = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.Text;
            selectCommand.CommandText = "select * from Customers where ContactName = @ContactName and PostalCode = @Password";

            selectCommand.Parameters.Add("@ContactName", SqlDbType.NChar);
            selectCommand.Parameters["@ContactName"].Value = username;

            selectCommand.Parameters.Add("@Password", SqlDbType.NChar);
            selectCommand.Parameters["@Password"].Value = password;

            try
            {
                connection.Open();
                SqlDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    customer = new CustomersBuilder(dataReader.GetString(0), dataReader.GetString(1))
                                                .ContactName(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                .ContactTitle(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                .Address(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                .City(dataReader.IsDBNull(5) ? (string)null : dataReader.GetString(5))
                                                .Region(dataReader.IsDBNull(6) ? (string)null : dataReader.GetString(6))
                                                .PostalCode(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                .Country(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                .Phone(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                .Fax(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                .Build();
                }
                dataReader.Close();
            }
            catch (Exception exc)
            {
                logger.logError(DateTime.Now, "Error while trying to get Customer with ContactName = " + username + " and PostalCode = " + password);
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
            logger.logInfo(DateTime.Now, "GetCustomerById method has sucessfully invoked.");
            return customer;
        }

        public string addCustomers(Customers customer)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddCustomer";

            insertCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            insertCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ContactName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ContactTitle", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Address", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@City", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Region", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Country", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Fax", SqlDbType.NVarChar);

            insertCommand.Parameters["@CustomerID"].Value = customer.CustomerID;
            insertCommand.Parameters["@CompanyName"].Value = customer.CompanyName;
            insertCommand.Parameters["@ContactName"].Value = customer.ContactName;
            insertCommand.Parameters["@ContactTitle"].Value = customer.ContactTitle;
            insertCommand.Parameters["@Address"].Value = customer.Address;
            insertCommand.Parameters["@City"].Value = customer.City;
            insertCommand.Parameters["@Region"].Value = customer.Region;
            insertCommand.Parameters["@PostalCode"].Value = customer.PostalCode;
            insertCommand.Parameters["@Country"].Value = customer.Country;
            insertCommand.Parameters["@Phone"].Value = customer.Phone;
            insertCommand.Parameters["@Fax"].Value = customer.Fax;

            string index = null;
            try
            {
                connection.Open();
                index = Convert.ToString(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddCustomers method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Customer.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public string updateCustomers(Customers customer)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateCustomer";

            updateCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            updateCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ContactName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ContactTitle", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Address", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@City", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Region", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Country", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Fax", SqlDbType.NVarChar);

            updateCommand.Parameters["@CustomerID"].Value = customer.CustomerID;
            updateCommand.Parameters["@CompanyName"].Value = customer.CompanyName;
            updateCommand.Parameters["@ContactName"].Value = customer.ContactName;
            updateCommand.Parameters["@ContactTitle"].Value = customer.ContactTitle;
            updateCommand.Parameters["@Address"].Value = customer.Address;
            updateCommand.Parameters["@City"].Value = customer.City;
            updateCommand.Parameters["@Region"].Value = customer.Region;
            updateCommand.Parameters["@PostalCode"].Value = customer.PostalCode;
            updateCommand.Parameters["@Country"].Value = customer.Country;
            updateCommand.Parameters["@Phone"].Value = customer.Phone;
            updateCommand.Parameters["@Fax"].Value = customer.Fax;

            string index = null;
            try
            {
                connection.Open();
                index = Convert.ToString(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateCustomer method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update customer.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteCustomers(string customerID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteCustomer";

            deleteCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            deleteCommand.Parameters["@CustomerID"].Value = customerID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteCustomer method has sucessfully invoked on Customer with CustomerID = " + customerID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
