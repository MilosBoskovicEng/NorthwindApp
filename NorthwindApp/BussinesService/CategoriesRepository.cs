using DAL;
using InfrastucturedServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Categories;

namespace BussinesService
{
    public class CategoriesRepository : ICategories
    {
        LoggerService logger = new LoggerService();

        public List<Categories> getAllCategories()
        {
            List<Categories> categoriesList = new List<Categories>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Categories", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Categories category = new CategoriesBuilder(dataReader.GetInt32(0), dataReader.GetString(1))
                                                .Description(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                .Picture(dataReader.IsDBNull(3) ? null : (byte[])(dataReader.GetValue(3)))
                                                .Build();
                        categoriesList.Add(category);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all categories.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllCategories method has sucessfully invoked.");
                return categoriesList;
            }
        }

        public Categories getCategoryById(int categoryID)
        {
            Categories category = null;
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetCategoryById";

            selectCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            selectCommand.Parameters["@CategoryID"].Value = categoryID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        category = new CategoriesBuilder(dataReader.GetInt32(0), dataReader.GetString(1))
                                                .Description(dataReader.IsDBNull(2) ? (string)null : dataReader.GetString(2))
                                                .Picture(dataReader.IsDBNull(3) ? null : (byte[])(dataReader.GetValue(3)))
                                                .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get categoriy with CategoryID = " + categoryID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetCategoryById method has sucessfully invoked.");
                return category;
            }
        }

        public int addCategory(Categories category)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddCategories";

            insertCommand.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Description", SqlDbType.NText);
            insertCommand.Parameters.Add("@Picture", SqlDbType.Image);

            insertCommand.Parameters["@CategoryName"].Value = category.CategoryName;
            insertCommand.Parameters["@Description"].Value = category.Description;
            insertCommand.Parameters["@Picture"].Value = category.Picture;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddCategory method has sucessfully invoked.");
                return index; 
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Category.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateCategory(Categories category)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateCategories";

            updateCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            updateCommand.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Description", SqlDbType.NText);
            updateCommand.Parameters.Add("@Picture", SqlDbType.Image);

            updateCommand.Parameters["@CategoryID"].Value = category.CategoryID;
            updateCommand.Parameters["@CategoryName"].Value = category.CategoryName;
            updateCommand.Parameters["@Description"].Value = category.Description;
            updateCommand.Parameters["@Picture"].Value = category.Picture;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateCategory method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update category.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteCategory(int categoryID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteCategories";

            deleteCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
            deleteCommand.Parameters["@CategoryID"].Value = categoryID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteCategory method has sucessfully invoked on Category with CategoryID = " + categoryID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete category with CategoryID = " + categoryID + ".");
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
