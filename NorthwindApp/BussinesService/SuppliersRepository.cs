using DAL;
using InfrastucturedServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Suppliers;

namespace BussinesService
{
    public class SuppliersRepository : ISuppliers
    {
        LoggerService logger = new LoggerService();

        public List<Suppliers> getAllSuppliers()
        {
            List<Suppliers> suppliersList = new List<Suppliers>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Suppliers", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Suppliers supplier = new SuppliersBuilder(dataReader.GetInt32(0), dataReader.GetString(1))
                                                                .ContactName(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                                .ContactTitle(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                                .Address(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                                .City(dataReader.IsDBNull(5) ? (string)null : dataReader.GetString(5))
                                                                .Region(dataReader.IsDBNull(6) ? (string)null : dataReader.GetString(6))
                                                                .PostalCode(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                                .Country(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                                .Phone(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                                .Fax(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                                .HomePage(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                                                .Build();

                        suppliersList.Add(supplier);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Suppliers.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllSuppliers method has sucessfully invoked.");
                return suppliersList;
            }
        }

        public Suppliers getSupplierById(int supplierID)
        {
            Suppliers supplier = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetSuppliersById";

            selectCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
            selectCommand.Parameters["@SupplierID"].Value = supplierID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        supplier = new SuppliersBuilder(dataReader.GetInt32(0), dataReader.GetString(1))
                                                                .ContactName(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                                .ContactTitle(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                                .Address(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                                .City(dataReader.IsDBNull(5) ? (string)null : dataReader.GetString(5))
                                                                .Region(dataReader.IsDBNull(6) ? (string)null : dataReader.GetString(6))
                                                                .PostalCode(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                                .Country(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                                .Phone(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                                .Fax(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                                .HomePage(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                                                .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Supplier with SupplierID = " + supplierID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetSupplierById method has sucessfully invoked.");
                return supplier;
            }
        }

        public int addSupplier(Suppliers supplier)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddSuppliers";
            
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
            insertCommand.Parameters.Add("@HomePage", SqlDbType.NText);

            insertCommand.Parameters["@CompanyName"].Value = supplier.CompanyName;
            insertCommand.Parameters["@ContactName"].Value = supplier.ContactName;
            insertCommand.Parameters["@ContactTitle"].Value = supplier.ContactTitle;
            insertCommand.Parameters["@Address"].Value = supplier.Address;
            insertCommand.Parameters["@City"].Value = supplier.City;
            insertCommand.Parameters["@Region"].Value = supplier.Region;
            insertCommand.Parameters["@PostalCode"].Value = supplier.PostalCode;
            insertCommand.Parameters["@Country"].Value = supplier.Country;
            insertCommand.Parameters["@Phone"].Value = supplier.Phone;
            insertCommand.Parameters["@Fax"].Value = supplier.Fax;
            insertCommand.Parameters["@HomePage"].Value = supplier.HomePage;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddSupplier method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Supplier.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateSupplier(Suppliers supplier)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateSuppliers";

            updateCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
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
            updateCommand.Parameters.Add("@HomePage", SqlDbType.NText);

            updateCommand.Parameters["@SupplierID"].Value = supplier.SupplierID;
            updateCommand.Parameters["@CompanyName"].Value = supplier.CompanyName;
            updateCommand.Parameters["@ContactName"].Value = supplier.ContactName;
            updateCommand.Parameters["@ContactTitle"].Value = supplier.ContactTitle;
            updateCommand.Parameters["@Address"].Value = supplier.Address;
            updateCommand.Parameters["@City"].Value = supplier.City;
            updateCommand.Parameters["@Region"].Value = supplier.Region;
            updateCommand.Parameters["@PostalCode"].Value = supplier.PostalCode;
            updateCommand.Parameters["@Country"].Value = supplier.Country;
            updateCommand.Parameters["@Phone"].Value = supplier.Phone;
            updateCommand.Parameters["@Fax"].Value = supplier.Fax;
            updateCommand.Parameters["@HomePage"].Value = supplier.HomePage;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateSupplier method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Suppliers.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteSupplier(int supplierID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteSuppliers";

            deleteCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
            deleteCommand.Parameters["@SupplierID"].Value = supplierID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteSupplier method has sucessfully invoked on Supplier with SupplierID = " + supplierID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Supplier with SupplierID = " + supplierID + ".");
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
