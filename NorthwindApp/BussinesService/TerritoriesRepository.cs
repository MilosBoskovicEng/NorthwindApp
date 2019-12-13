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
    public class TerritoriesRepository : ITerritories
    {
        LoggerService logger = new LoggerService();

        public List<Territories> getAllTerritories()
        {
            List<Territories> territoriesList = new List<Territories>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Territories", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Territories territory = new Territories(dataReader.GetString(0),dataReader.GetString(1),dataReader.GetInt32(2));
                        territoriesList.Add(territory);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Territories.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllTerritories method has sucessfully invoked.");
                return territoriesList;
            }
        }

        public Territories getTerritoryById(string territoryID)
        {
            Territories territory = new Territories();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetTerritoryById";

            selectCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);
            selectCommand.Parameters["@TerritoryID"].Value = territoryID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        territory.TerritoryID = dataReader.GetString(0);
                        territory.TerritoryDescription = dataReader.GetString(1);
                        territory.RegionID = dataReader.GetInt32(2);
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Territory with TerritoryID = " + territoryID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetTerritoryById method has sucessfully invoked.");
                return territory;
            }
        }

        public string addTerritory(Territories territory)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddTerritory";

            insertCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@TerritoryDescription", SqlDbType.NChar);
            insertCommand.Parameters.Add("@RegionID", SqlDbType.Int);

            insertCommand.Parameters["@TerritoryID"].Value = territory.TerritoryID;
            insertCommand.Parameters["@TerritoryDescription"].Value = territory.TerritoryDescription;
            insertCommand.Parameters["@RegionID"].Value = territory.RegionID;


            string index = null;
            try
            {
                connection.Open();
                index = Convert.ToString(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddTerritory method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Territory.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public string updateTerritory(Territories territory)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateTerritory";

            updateCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@TerritoryDescription", SqlDbType.NChar);
            updateCommand.Parameters.Add("@RegionID", SqlDbType.Int);

            updateCommand.Parameters["@TerritoryID"].Value = territory.TerritoryID;
            updateCommand.Parameters["@TerritoryDescription"].Value = territory.TerritoryDescription;
            updateCommand.Parameters["@RegionID"].Value = territory.RegionID;

            string index = null;
            try
            {
                connection.Open();
                index = Convert.ToString(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "updateTerritory method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Territory.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteTerritory(string territoryID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteTerritory";

            deleteCommand.Parameters.Add("@TerritoryID", SqlDbType.NVarChar);
            deleteCommand.Parameters["@TerritoryID"].Value = territoryID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteTerritory method has sucessfully invoked on Territory with TerritoryID = " + territoryID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Territory with TerritoryID = " + territoryID + ".");
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
