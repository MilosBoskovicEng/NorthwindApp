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
    public class ShippersRepository : IShippers
    {
        LoggerService logger = new LoggerService();

        public List<Shippers> getAllShippers()
        {
            List<Shippers> shippersList = new List<Shippers>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Shippers", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Shippers shipper = new Shippers(dataReader.GetInt32(0),dataReader.GetString(1));
                        shipper.Phone = dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2);
                        shippersList.Add(shipper);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Shippers.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllShippers method has sucessfully invoked.");
                return shippersList;
            }
        }

        public Shippers getShipperById(int shipperID)
        {
            Shippers shipper = new Shippers();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetShipperById";

            selectCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            selectCommand.Parameters["@ShipperID"].Value = shipperID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        shipper.ShipperID = dataReader.GetInt32(0);
                        shipper.CompanyName = dataReader.GetString(1);
                        shipper.Phone = dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Shipper with ShipperID = " + shipperID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetShipperById method has sucessfully invoked.");
                return shipper;
            }
        }

        public int addShippers(Shippers customer)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddShipper";

            insertCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);

            insertCommand.Parameters["@CompanyName"].Value = customer.CompanyName;
            insertCommand.Parameters["@Phone"].Value = customer.Phone;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddShippers method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Shipper.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateShippers(Shippers customer)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateShipper";

            updateCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            updateCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);

            updateCommand.Parameters["@ShipperID"].Value = customer.ShipperID;
            updateCommand.Parameters["@CompanyName"].Value = customer.CompanyName;
            updateCommand.Parameters["@Phone"].Value = customer.Phone;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateShippers method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Shippers.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteShippers(int shipperID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteShipper";

            deleteCommand.Parameters.Add("@ShipperID", SqlDbType.Int);
            deleteCommand.Parameters["@ShipperID"].Value = shipperID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteShippers method has sucessfully invoked on Shipper with ShipperID = " + shipperID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Shipper with ShipperID = " + shipperID + ".");
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
