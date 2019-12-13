using DAL;
using InfrastucturedServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Products;

namespace BussinesService
{
    public class ProductsRepository : IProducts
    {
        LoggerService logger = new LoggerService();

        public List<Products> getAllProducts()
        {
            List<Products> productsList = new List<Products>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Products", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Products product = new ProductsBuilder(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetBoolean(9))
                                                            .SupplierID(dataReader.IsDBNull(2) ? (int?)null : dataReader.GetInt32(2))
                                                            .CategoryID(dataReader.IsDBNull(3) ? (int?)null : dataReader.GetInt32(3))
                                                            .QuantityPerUnit(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                            .UnitPrice(dataReader.IsDBNull(5) ? (decimal?)null : dataReader.GetDecimal(5))
                                                            .UnitsInStock(dataReader.IsDBNull(6) ? (short?)null : dataReader.GetInt16(6))
                                                            .UnitsOnOrder(dataReader.IsDBNull(7) ? (short?)null : dataReader.GetInt16(7))
                                                            .ReorderLevel(dataReader.IsDBNull(8) ? (short?)null : dataReader.GetInt16(8))
                                                            .Build();

                        productsList.Add(product);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Products.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllProducts method has sucessfully invoked.");
                return productsList;
            }
        }

        public Products getProductById(int productID)
        {
            Products product = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetProductById";

            selectCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            selectCommand.Parameters["@ProductID"].Value = productID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        product = new ProductsBuilder(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetBoolean(9))
                                                            .SupplierID(dataReader.IsDBNull(2) ? (int?)null : dataReader.GetInt32(2))
                                                            .CategoryID(dataReader.IsDBNull(3) ? (int?)null : dataReader.GetInt32(3))
                                                            .QuantityPerUnit(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                            .UnitPrice(dataReader.IsDBNull(5) ? (decimal?)null : dataReader.GetDecimal(5))
                                                            .UnitsInStock(dataReader.IsDBNull(6) ? (short?)null : dataReader.GetInt16(6))
                                                            .UnitsOnOrder(dataReader.IsDBNull(7) ? (short?)null : dataReader.GetInt16(7))
                                                            .ReorderLevel(dataReader.IsDBNull(8) ? (short?)null : dataReader.GetInt16(8))
                                                            .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Product with ProductID = " + productID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetProductById method has sucessfully invoked.");
                return product;
            }
        }

        public int addProduct(Products product)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddProduct";

            insertCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
            insertCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            insertCommand.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            insertCommand.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            insertCommand.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            insertCommand.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            insertCommand.Parameters.Add("@Discontinued", SqlDbType.Bit);

            insertCommand.Parameters["@ProductName"].Value = product.ProductName;
            insertCommand.Parameters["@SupplierID"].Value = product.SupplierID;
            insertCommand.Parameters["@CategoryID"].Value = product.CategoryID;
            insertCommand.Parameters["@QuantityPerUnit"].Value = product.QuantityPerUnit;
            insertCommand.Parameters["@UnitPrice"].Value = product.UnitPrice;
            insertCommand.Parameters["@UnitsInStock"].Value = product.UnitsInStock;
            insertCommand.Parameters["@UnitsOnOrder"].Value = product.UnitsOnOreder;
            insertCommand.Parameters["@ReorderLevel"].Value = product.ReorderLevel;
            insertCommand.Parameters["@Discontinued"].Value = product.Discontinued;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddProduct method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Product.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateProduct(Products product)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateProduct";

            updateCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            updateCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
            updateCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            updateCommand.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
            updateCommand.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            updateCommand.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            updateCommand.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            updateCommand.Parameters.Add("@Discontinued", SqlDbType.Bit);

            updateCommand.Parameters["@ProductID"].Value = product.ProductID;
            updateCommand.Parameters["@ProductName"].Value = product.ProductName;
            updateCommand.Parameters["@SupplierID"].Value = product.SupplierID;
            updateCommand.Parameters["@CategoryID"].Value = product.CategoryID;
            updateCommand.Parameters["@QuantityPerUnit"].Value = product.QuantityPerUnit;
            updateCommand.Parameters["@UnitPrice"].Value = product.UnitPrice;
            updateCommand.Parameters["@UnitsInStock"].Value = product.UnitsInStock;
            updateCommand.Parameters["@UnitsOnOrder"].Value = product.UnitsOnOreder;
            updateCommand.Parameters["@ReorderLevel"].Value = product.ReorderLevel;
            updateCommand.Parameters["@Discontinued"].Value = product.Discontinued;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateProduct method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Product.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteProduct(int productID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteProduct";

            deleteCommand.Parameters.Add("@ProductID", SqlDbType.Int);
            deleteCommand.Parameters["@ProductID"].Value = productID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteProduct method has sucessfully invoked on Product with ProductID = " + productID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Product with ProductID = " + productID + ".");
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
