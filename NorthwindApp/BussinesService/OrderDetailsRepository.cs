using DAL;
using InfrastucturedServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BussinesService
{
    public class OrderDetailsRepository : IOrderDetails
    {
        LoggerService logger = new LoggerService();

        public List<OrderDetails> getAllOrderDetails()
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from [Order Details]", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        OrderDetails orderDetails = new OrderDetails();
                        orderDetails.OrderID = dataReader.GetInt32(0);
                        orderDetails.ProductID = dataReader.GetInt32(1);
                        orderDetails.UnitPrice = dataReader.GetDecimal(2);
                        orderDetails.Quantity = dataReader.GetInt16(3);
                        orderDetails.Discount = dataReader.GetFloat(4);
                        orderDetailsList.Add(orderDetails);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all OrderDetails.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllOrderDetails method has sucessfully invoked.");
                return orderDetailsList;
            }
        }

        public OrderDetails getOrderDetailsById(int orderID, int productID)
        {
            OrderDetails orderDetails = new OrderDetails();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetOrderDetailsById";

            selectCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            selectCommand.Parameters.Add("@ProductID", SqlDbType.Int);

            selectCommand.Parameters["@OrderID"].Value = orderID;
            selectCommand.Parameters["@ProductID"].Value = productID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        orderDetails.OrderID = dataReader.GetInt32(0);
                        orderDetails.ProductID = dataReader.GetInt32(1);
                        orderDetails.UnitPrice = dataReader.GetDecimal(2);
                        orderDetails.Quantity = dataReader.GetInt16(3);
                        orderDetails.Discount = dataReader.GetFloat(4);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get OrderDetails with OrderID = " + orderID + " and ProductID = " + productID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetOrderDetailsById method has sucessfully invoked.");
                return orderDetails;
            }
        }

        public int addOrderDetails(OrderDetails orderDetails)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddOrderDetails";
            
            insertCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            insertCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            insertCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            insertCommand.Parameters.Add("@Quantity", SqlDbType.SmallInt);
            insertCommand.Parameters.Add("@Discount", SqlDbType.Real);

            insertCommand.Parameters["@OrderID"].Value = orderDetails.OrderID;
            insertCommand.Parameters["@ProductID"].Value = orderDetails.ProductID;
            insertCommand.Parameters["@UnitPrice"].Value = orderDetails.UnitPrice;
            insertCommand.Parameters["@Quantity"].Value = orderDetails.Quantity;
            insertCommand.Parameters["@Discount"].Value = orderDetails.Discount;

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "AddOrderDetails method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new OrderDetails.");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateOrderDetails(OrderDetails orderDetails)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateOrderDetails";

            updateCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            updateCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            updateCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            updateCommand.Parameters.Add("@Quantity", SqlDbType.SmallInt);
            updateCommand.Parameters.Add("@Discount", SqlDbType.Real);

            updateCommand.Parameters["@OrderID"].Value = orderDetails.OrderID;
            updateCommand.Parameters["@ProductID"].Value = orderDetails.ProductID;
            updateCommand.Parameters["@UnitPrice"].Value = orderDetails.UnitPrice;
            updateCommand.Parameters["@Quantity"].Value = orderDetails.Quantity;
            updateCommand.Parameters["@Discount"].Value = orderDetails.Discount;

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "UpdateOrderDetails method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update OrderDetails.");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteOrderDetails(int orderID, int productID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteOrderDetails";

            deleteCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            deleteCommand.Parameters.Add("@ProductID", SqlDbType.Int);

            deleteCommand.Parameters["@OrderID"].Value = orderID;
            deleteCommand.Parameters["@ProductID"].Value = productID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteOrderDetails method has sucessfully invoked on OrderDetails with OrderID = " + orderID + " and ProductID = " + productID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete OrderDetails with OrderID = " + orderID + " and ProductID = " + productID + ".");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int addTransactionlOrderDetails(Orders order, Dictionary<int, OrderItem> cart)
        {
            Connection conn = new Connection();
            SqlTransaction transaction;
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertOrderCommand = new SqlCommand();
            insertOrderCommand.Connection = connection;
            insertOrderCommand.CommandType = CommandType.StoredProcedure;
            insertOrderCommand.CommandText = "AddOrder";

            insertOrderCommand.Parameters.Add("@CustomerID", SqlDbType.NChar);
            insertOrderCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            insertOrderCommand.Parameters.Add("@OrderDate", SqlDbType.DateTime);
            insertOrderCommand.Parameters.Add("@RequiredDate", SqlDbType.DateTime);
            insertOrderCommand.Parameters.Add("@ShippedDate", SqlDbType.DateTime);
            insertOrderCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            insertOrderCommand.Parameters.Add("@Freight", SqlDbType.Money);
            insertOrderCommand.Parameters.Add("@ShipName", SqlDbType.NVarChar);
            insertOrderCommand.Parameters.Add("@ShipAddress", SqlDbType.NVarChar);
            insertOrderCommand.Parameters.Add("@ShipCity", SqlDbType.NVarChar);
            insertOrderCommand.Parameters.Add("@ShipRegion", SqlDbType.NVarChar);
            insertOrderCommand.Parameters.Add("@ShipPostalCode", SqlDbType.NVarChar);
            insertOrderCommand.Parameters.Add("@ShipCountry", SqlDbType.NVarChar);


            insertOrderCommand.Parameters["@CustomerID"].Value = order.CustomerID;
            insertOrderCommand.Parameters["@EmployeeID"].Value = order.EmployeeID;
            insertOrderCommand.Parameters["@OrderDate"].Value = order.OrderDate;
            insertOrderCommand.Parameters["@RequiredDate"].Value = order.RequiredDate;
            insertOrderCommand.Parameters["@ShippedDate"].Value = order.ShippedDate;
            insertOrderCommand.Parameters["@ShipperID"].Value = order.ShipperID;
            insertOrderCommand.Parameters["@Freight"].Value = order.Freight;
            insertOrderCommand.Parameters["@ShipName"].Value = order.ShipName;
            insertOrderCommand.Parameters["@ShipAddress"].Value = order.ShipAddress;
            insertOrderCommand.Parameters["@ShipCity"].Value = order.ShipCity;
            insertOrderCommand.Parameters["@ShipRegion"].Value = order.ShipRegion;
            insertOrderCommand.Parameters["@ShipPostalCode"].Value = order.ShipPostalCode;
            insertOrderCommand.Parameters["@ShipCountry"].Value = order.ShipCountry;

            SqlCommand insertDetailsCommand = new SqlCommand();
            insertDetailsCommand.Connection = connection;
            insertDetailsCommand.CommandType = CommandType.StoredProcedure;
            insertDetailsCommand.CommandText = "AddOrderDetails";

            insertDetailsCommand.Parameters.Add("@OrderID", SqlDbType.Int);
            insertDetailsCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            insertDetailsCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            insertDetailsCommand.Parameters.Add("@Quantity", SqlDbType.SmallInt);
            insertDetailsCommand.Parameters.Add("@Discount", SqlDbType.Real);

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                insertOrderCommand.Transaction = transaction;
                int orderID = Convert.ToInt32(insertOrderCommand.ExecuteScalar());

                foreach (int key in cart.Keys)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderID = orderID;
                    orderDetails.ProductID = cart[key].ProductId;
                    orderDetails.Quantity = (short)cart[key].Quantity;
                    orderDetails.UnitPrice = (decimal)cart[key].Products.UnitPrice;
                    orderDetails.Discount = 0.15f;

                    insertDetailsCommand.Parameters["@OrderID"].Value = orderDetails.OrderID;
                    insertDetailsCommand.Parameters["@ProductID"].Value = orderDetails.ProductID;
                    insertDetailsCommand.Parameters["@UnitPrice"].Value = orderDetails.UnitPrice;
                    insertDetailsCommand.Parameters["@Quantity"].Value = orderDetails.Quantity;
                    insertDetailsCommand.Parameters["@Discount"].Value = orderDetails.Discount;
                    insertDetailsCommand.Transaction = transaction;
                    insertDetailsCommand.ExecuteScalar();
                }
                transaction.Commit();
                return 1;
            }
            catch(Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new OrderDetails.");
                MessageBox.Show(ex.Message);
                return 0; ;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
