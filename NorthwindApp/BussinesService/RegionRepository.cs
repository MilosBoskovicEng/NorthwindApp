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
    public class RegionRepository : IRegion
    {
        LoggerService logger = new LoggerService();

        public List<Region> getAllRegions()
        {
            List<Region> regionsList = new List<Region>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Region", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Region region = new Region(dataReader.GetInt32(0), dataReader.GetString(1));
                        regionsList.Add(region);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Regions.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "getAllRegions method has sucessfully invoked.");
                return regionsList;
            }
        }

        public Region getRegionById(int regionID)
        {
            Region region = new Region();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetRegionById";

            selectCommand.Parameters.Add("@RegionID", SqlDbType.Int);
            selectCommand.Parameters["@RegionID"].Value = regionID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        region.RegionID = dataReader.GetInt32(0);
                        region.RegionDescription = dataReader.GetString(1);                   
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Region with RegionID = " + regionID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetRegionById method has sucessfully invoked.");
                return region;
            }
        }

        public int addRegion(Region region)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddRegion";

            insertCommand.Parameters.Add("@RegionDescription", SqlDbType.NChar);
            insertCommand.Parameters["@RegionDescription"].Value = region.RegionDescription;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddRegion method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Region.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateRegion(Region region)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateRegion";

            updateCommand.Parameters.Add("@RegionID", SqlDbType.Int);
            updateCommand.Parameters.Add("@RegionDescription", SqlDbType.NChar);

            updateCommand.Parameters["@RegionID"].Value = region.RegionID;
            updateCommand.Parameters["@RegionDescription"].Value = region.RegionDescription;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateRegion method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Region.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteRegion(int regionID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteRegion";

            deleteCommand.Parameters.Add("@RegionID", SqlDbType.Int);
            deleteCommand.Parameters["@RegionID"].Value = regionID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteRegion method has sucessfully invoked on Region with RegionID = " + regionID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Region with RegionID = " + regionID + ".");
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
