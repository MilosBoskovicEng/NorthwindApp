using DAL;
using System;
using System.Collections.Generic;
using Model;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using InfrastucturedServices;

namespace BussinesService
{
    public class CustomerCustomerDemoRepository : ICustomerCustomerDemo
    {
        LoggerService logger = new LoggerService();

        public List<CustomerCustomerDemo> getAllCustomerCustomerDemo()
        {
            List<CustomerCustomerDemo> customerCustomerDemoList = new List<CustomerCustomerDemo>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from CustomerCustomerDemo", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        CustomerCustomerDemo customerCustomerDemo = new CustomerCustomerDemo(dataReader.GetString(0), dataReader.GetString(1));
                        customerCustomerDemoList.Add(customerCustomerDemo);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all CustomerCustomerDemo.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllCustomerCustomerDemo method has sucessfully invoked.");
                return customerCustomerDemoList;
            }
        }

        public CustomerCustomerDemo getCustomerCustomerDemoById(string customerID, string CustomerTypeID)
        {
            CustomerCustomerDemo customerCustomerDemo = new CustomerCustomerDemo();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetCustomerCustomerDemoById";

            selectCommand.Parameters.Add("@CustomerID", SqlDbType.NChar); 
            selectCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);

            selectCommand.Parameters["@CustomerID"].Value = customerID;
            selectCommand.Parameters["@CustomerTypeID"].Value = CustomerTypeID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        customerCustomerDemo.CustomerID = dataReader.GetString(0);
                        customerCustomerDemo.CustomerTypeID = dataReader.GetString(1);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get CustomerCustomerDemo with CustomerID = " + customerID + " and CustomerTypeID = " + CustomerTypeID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetCustomerCustomerDemoById method has sucessfully invoked.");
                return customerCustomerDemo;
            }
        }

        public int addCustomerCustomerDemo(CustomerCustomerDemo customerCustomerDemo)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddCustomerCustomerDemo";

            insertCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            insertCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);

            insertCommand.Parameters["@CustomerID"].Value = customerCustomerDemo.CustomerID;
            insertCommand.Parameters["@CustomerTypeID"].Value = customerCustomerDemo.CustomerTypeID;

            
            try
            {
                connection.Open();
                insertCommand.ExecuteScalar();
                logger.logInfo(DateTime.Now, "AddCustomerCustomerDemo method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new CustomerCustomerDemo.");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteCustomerCustomerDemo(string customerID, string CustomerTypeID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteCustomerCustomerDemo";

            deleteCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            deleteCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);

            deleteCommand.Parameters["@CustomerID"].Value = customerID;
            deleteCommand.Parameters["@CustomerTypeID"].Value = CustomerTypeID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteCustomerCustomerDemo method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete CustomerCustomerDemo with CustomerID = " + customerID + " and CustomerTypeID = " + CustomerTypeID + ".");
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
