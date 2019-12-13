using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using InfrastucturedServices;

namespace BussinesService
{
    public class CustomerDemographicsRepository : ICustomerDemographics
    {
        LoggerService logger = new LoggerService();

        public List<CustomerDemographics> getAllCustomerDemographics()
        {
            List<CustomerDemographics> customerDemographicsList = new List<CustomerDemographics>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from CustomerDemographics", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        CustomerDemographics customerDemographics = new CustomerDemographics(dataReader.GetString(0)); 
                        customerDemographics.CustomerDesc = dataReader.IsDBNull(1) ? (string)null : dataReader.GetString(1);
                        customerDemographicsList.Add(customerDemographics);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all CustomerDemographics.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllCustomerDemographics method has sucessfully invoked.");
                return customerDemographicsList;
            }
        }

        public CustomerDemographics getCustomerDemographicsById(string CustomerTypeID)
        {
            CustomerDemographics customerDemographics = new CustomerDemographics();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetCustomerDemographicsById";

            selectCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);
            selectCommand.Parameters["@CustomerTypeID"].Value = CustomerTypeID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        customerDemographics.CustomerTypeID = dataReader.GetString(0);
                        customerDemographics.CustomerDesc = dataReader.IsDBNull(1) ? (string)null : dataReader.GetString(1);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get CustomerDemographics with CustomerTypeID = " + CustomerTypeID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetCustomerDemographicsById method has sucessfully invoked.");
                return customerDemographics;
            }
        }

        public string addCustomerDemographics(CustomerDemographics customerDemographics)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddCustomerDemographics";

            insertCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);
            insertCommand.Parameters.Add("@CustomerDesc", SqlDbType.NText);

            insertCommand.Parameters["@CustomerTypeID"].Value = customerDemographics.CustomerTypeID;
            insertCommand.Parameters["@CustomerDesc"].Value = customerDemographics.CustomerDesc;

            string index = null;
            try
            {
                connection.Open();
                index = Convert.ToString(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddCustomerDemographics method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new CustomerDemographics.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public string updateCustomerDemographics(CustomerDemographics customerDemographics)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateCustomerDemographics";

            updateCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);
            updateCommand.Parameters.Add("@CustomerDesc", SqlDbType.NText);

            updateCommand.Parameters["@CustomerTypeID"].Value = customerDemographics.CustomerTypeID;
            updateCommand.Parameters["@CustomerDesc"].Value = customerDemographics.CustomerDesc;

            string index = "";
            try
            {
                connection.Open();
                index = Convert.ToString(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateCustomerDemographics method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update CustomerDemographics.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteCustomerDemographics(string CustomerTypeID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteCustomerDemographics";

            deleteCommand.Parameters.Add("@CustomerTypeID", SqlDbType.NChar);
            deleteCommand.Parameters["@CustomerTypeID"].Value = CustomerTypeID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteCustomerDemographics method has sucessfully invoked on CustomerDemographics with CustomerTypeID = " + CustomerTypeID + ".");
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
