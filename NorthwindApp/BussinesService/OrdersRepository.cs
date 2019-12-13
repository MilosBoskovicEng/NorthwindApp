using DAL;
using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Orders;
using System.Data;
using InfrastucturedServices;

namespace BussinesService
{
    public class OrdersRepository : IOrders
    {
        LoggerService logger = new LoggerService();

        public List<Orders> getAllOrders()
        {
            List<Orders> ordersList = new List<Orders>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Orders", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Orders order = new OrdersBuilder(dataReader.GetInt32(0))
                                        .CustomerID(dataReader.IsDBNull(1) ? (string)null : dataReader.GetString(1))
                                        .EmployeeID(dataReader.IsDBNull(2) ? (int?)null : dataReader.GetInt32(2))
                                        .OrderDate(dataReader.IsDBNull(3) ? (DateTime?)null : dataReader.GetDateTime(3))
                                        .RequiredDate(dataReader.IsDBNull(4) ? (DateTime?)null : dataReader.GetDateTime(4))
                                        .ShippedDate(dataReader.IsDBNull(5) ? (DateTime?)null : dataReader.GetDateTime(5))
                                        .ShipperID(dataReader.IsDBNull(6) ? (int?)null : dataReader.GetInt32(6))
                                        .Freight(dataReader.IsDBNull(7) ? (decimal?)null : dataReader.GetDecimal(7))
                                        .ShipName(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                        .ShipAddress(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                        .ShipCity(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                        .ShipRegion(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                        .ShipPostalCode(dataReader.IsDBNull(12) ? (string)null : dataReader.GetString(12))
                                        .ShipCountry(dataReader.IsDBNull(13) ? (string)null : dataReader.GetString(13))
                                        .Build();

                        ordersList.Add(order);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all orders.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllOrders method has sucessfully invoked.");
                return ordersList;
            }
        }

        public Orders getOrdersById(int orderID)
        {
            Orders order = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetOrderById";

            selectCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            selectCommand.Parameters["@OrderID"].Value = orderID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        order = new OrdersBuilder(dataReader.GetInt32(0))
                                        .CustomerID(dataReader.IsDBNull(1) ? (string)null : dataReader.GetString(1))
                                        .EmployeeID(dataReader.IsDBNull(2) ? (int?)null : dataReader.GetInt32(2))
                                        .OrderDate(dataReader.IsDBNull(3) ? (DateTime?)null : dataReader.GetDateTime(3))
                                        .RequiredDate(dataReader.IsDBNull(4) ? (DateTime?)null : dataReader.GetDateTime(4))
                                        .ShippedDate(dataReader.IsDBNull(5) ? (DateTime?)null : dataReader.GetDateTime(5))
                                        .ShipperID(dataReader.IsDBNull(6) ? (int?)null : dataReader.GetInt32(6))
                                        .Freight(dataReader.IsDBNull(7) ? (decimal?)null : dataReader.GetDecimal(7))
                                        .ShipName(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                        .ShipAddress(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                        .ShipCity(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                        .ShipRegion(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                        .ShipPostalCode(dataReader.IsDBNull(12) ? (string)null : dataReader.GetString(12))
                                        .ShipCountry(dataReader.IsDBNull(13) ? (string)null : dataReader.GetString(13))
                                        .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Order with OrderID = " + orderID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetOrdersById method has sucessfully invoked.");
                return order;
            }
        }

        public int addOrders(Orders order)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddOrder";

            insertCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            insertCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            insertCommand.Parameters.Add("@OrderDate", SqlDbType.DateTime);
            insertCommand.Parameters.Add("@RequiredDate", SqlDbType.DateTime);
            insertCommand.Parameters.Add("@ShippedDate", SqlDbType.DateTime);
            insertCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            insertCommand.Parameters.Add("@Freight", SqlDbType.Money);
            insertCommand.Parameters.Add("@ShipName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ShipAddress", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ShipCity", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ShipRegion", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ShipPostalCode", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@ShipCountry", SqlDbType.NVarChar);
            

            insertCommand.Parameters["@CustomerID"].Value = order.CustomerID;
            insertCommand.Parameters["@EmployeeID"].Value = order.EmployeeID;
            insertCommand.Parameters["@OrderDate"].Value = order.OrderDate;
            insertCommand.Parameters["@RequiredDate"].Value = order.RequiredDate;
            insertCommand.Parameters["@ShippedDate"].Value = order.ShippedDate;
            insertCommand.Parameters["@ShipperID"].Value = order.ShipperID;
            insertCommand.Parameters["@Freight"].Value = order.Freight;
            insertCommand.Parameters["@ShipName"].Value = order.ShipName;
            insertCommand.Parameters["@ShipAddress"].Value = order.ShipAddress;
            insertCommand.Parameters["@ShipCity"].Value = order.ShipCity;
            insertCommand.Parameters["@ShipRegion"].Value = order.ShipRegion;
            insertCommand.Parameters["@ShipPostalCode"].Value = order.ShipPostalCode;
            insertCommand.Parameters["@ShipCountry"].Value = order.ShipCountry;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddOrders method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Order.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateOrders(Orders order)
        {

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateOrder";

            updateCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            updateCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            updateCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            updateCommand.Parameters.Add("@OrderDate", SqlDbType.DateTime);
            updateCommand.Parameters.Add("@RequiredDate", SqlDbType.DateTime);
            updateCommand.Parameters.Add("@ShippedDate", SqlDbType.DateTime);
            updateCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            updateCommand.Parameters.Add("@Freight", SqlDbType.Money);
            updateCommand.Parameters.Add("@ShipName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ShipAddress", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ShipCity", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ShipRegion", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ShipPostalCode", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@ShipCountry", SqlDbType.NVarChar);

            updateCommand.Parameters["@OrderID"].Value = order.OrderID;
            updateCommand.Parameters["@CustomerID"].Value = order.CustomerID;
            updateCommand.Parameters["@EmployeeID"].Value = order.EmployeeID;
            updateCommand.Parameters["@OrderDate"].Value = order.OrderDate;
            updateCommand.Parameters["@RequiredDate"].Value = order.RequiredDate;
            updateCommand.Parameters["@ShippedDate"].Value = order.ShippedDate;
            updateCommand.Parameters["@ShipperID"].Value = order.ShipperID;
            updateCommand.Parameters["@Freight"].Value = order.Freight;
            updateCommand.Parameters["@ShipName"].Value = order.ShipName;
            updateCommand.Parameters["@ShipAddress"].Value = order.ShipAddress;
            updateCommand.Parameters["@ShipCity"].Value = order.ShipCity;
            updateCommand.Parameters["@ShipRegion"].Value = order.ShipRegion;
            updateCommand.Parameters["@ShipPostalCode"].Value = order.ShipPostalCode;
            updateCommand.Parameters["@ShipCountry"].Value = order.ShipCountry;

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "UpdateOrders method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Order.");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteOrders(int orderID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteOrder";

            deleteCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            deleteCommand.Parameters["@OrderID"].Value = orderID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
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
