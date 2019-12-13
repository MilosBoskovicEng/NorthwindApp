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
    public class EmployeeTerritoriesRepository : IEmployeeTerritories
    {
        LoggerService logger = new LoggerService();

        public List<EmployeeTerritories> getAllEmployeeTerritories()
        {
            List<EmployeeTerritories> employeeTerritoriesList = new List<EmployeeTerritories>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from EmployeeTerritories", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        EmployeeTerritories employeeTerritories = new EmployeeTerritories();
                        employeeTerritories.EmployeeID = dataReader.GetInt32(0);
                        employeeTerritories.TerritoryID = dataReader.GetString(1);
                        employeeTerritoriesList.Add(employeeTerritories);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all EmployeeTerritories.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllEmployeeTerritories method has sucessfully invoked.");
                return employeeTerritoriesList;
            }
        }

        public EmployeeTerritories getEmployeeTerritoriesById(int employeeID, string territoryID)
        {
            EmployeeTerritories employeeTerritories = new EmployeeTerritories();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetEmployeeTerritoriesById";

            selectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            selectCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);

            selectCommand.Parameters["@EmployeeID"].Value = employeeID;
            selectCommand.Parameters["@TerritoryID"].Value = territoryID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        employeeTerritories.EmployeeID = dataReader.GetInt32(0);
                        employeeTerritories.TerritoryID = dataReader.GetString(1);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get EmployeeTerritories with EmployeeID = " + employeeID + " and TerritoryID = " + territoryID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetEmployeeTerritoriesById method has sucessfully invoked.");
                return employeeTerritories;
            }
        }

        public int addEmployeeTerritories(EmployeeTerritories employeeTerritories)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddEmployeeTerritories";

            insertCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            insertCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);

            insertCommand.Parameters["@EmployeeID"].Value = employeeTerritories.EmployeeID;
            insertCommand.Parameters["@TerritoryID"].Value = employeeTerritories.TerritoryID;

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "AddEmployeeTerritories method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new EmployeeTerritories.");
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteEmployeeTerritories(int employeeID, string territoryID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteEmployeeTerritories";

            deleteCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            deleteCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);

            deleteCommand.Parameters["@EmployeeID"].Value = employeeID;
            deleteCommand.Parameters["@TerritoryID"].Value = territoryID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteEmployeeTerritories method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete EmployeeTerritories with EmployeeID = " + employeeID + " and TerritoryID = " + territoryID + ".");
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
