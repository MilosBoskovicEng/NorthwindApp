using DAL;
using InfrastucturedServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Model.Employees;

namespace BussinesService
{
    public class EmployeesRepository : IEmployees
    {
        LoggerService logger = new LoggerService();

        public List<Employees> getAllEmployees()
        {
            List<Employees> employeesList = new List<Employees>();

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            using (SqlCommand command = new SqlCommand("select * from Employees", connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Employees employee = new EmployeeBuilder(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2))
                                                                .Title(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                                .TitleOfCourtesy(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                                .BirthDate(dataReader.IsDBNull(5) ? (DateTime?)null : dataReader.GetDateTime(5))
                                                                .HireDate(dataReader.IsDBNull(6) ? (DateTime?)null : dataReader.GetDateTime(6))
                                                                .Address(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                                .City(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                                .Region(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                                .PostalCode(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                                .Country(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                                                .HomePhone(dataReader.IsDBNull(12) ? (string)null : dataReader.GetString(12))
                                                                .Extension(dataReader.IsDBNull(13) ? (string)null : dataReader.GetString(13))
                                                                .Photo(dataReader.IsDBNull(14) ? null : (byte[])dataReader.GetValue(14))
                                                                .Notes(dataReader.IsDBNull(15) ? (string)null : dataReader.GetString(15))
                                                                .ReportsTo(dataReader.IsDBNull(16) ? (int?)null : dataReader.GetInt32(16))
                                                                .PhotoPath(dataReader.IsDBNull(17) ? (string)null : dataReader.GetString(17))
                                                                .Build();
                        
                        employeesList.Add(employee);
                    }

                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get all Employees.");
                    MessageBox.Show(exc.Message);
                }
                logger.logInfo(DateTime.Now, "GetAllEmployees method has sucessfully invoked.");
                return employeesList;
            }
        }

        public Employees getEmployeeById(int employeeID)
        {
            Employees employee = null;

            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;

            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "GetEmployeeById";

            selectCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            selectCommand.Parameters["@EmployeeID"].Value = employeeID;

            {
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = selectCommand.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        employee = new EmployeeBuilder(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2))
                                                    .Title(dataReader.IsDBNull(3) ? (string)null : dataReader.GetString(3))
                                                    .TitleOfCourtesy(dataReader.IsDBNull(4) ? (string)null : dataReader.GetString(4))
                                                    .BirthDate(dataReader.IsDBNull(5) ? (DateTime?)null : dataReader.GetDateTime(5))
                                                    .HireDate(dataReader.IsDBNull(6) ? (DateTime?)null : dataReader.GetDateTime(6))
                                                    .Address(dataReader.IsDBNull(7) ? (string)null : dataReader.GetString(7))
                                                    .City(dataReader.IsDBNull(8) ? (string)null : dataReader.GetString(8))
                                                    .Region(dataReader.IsDBNull(9) ? (string)null : dataReader.GetString(9))
                                                    .PostalCode(dataReader.IsDBNull(10) ? (string)null : dataReader.GetString(10))
                                                    .Country(dataReader.IsDBNull(11) ? (string)null : dataReader.GetString(11))
                                                    .HomePhone(dataReader.IsDBNull(12) ? (string)null : dataReader.GetString(12))
                                                    .Extension(dataReader.IsDBNull(13) ? (string)null : dataReader.GetString(13))
                                                    .Photo(dataReader.IsDBNull(14) ? null : (byte[])dataReader.GetValue(14))
                                                    .Notes(dataReader.IsDBNull(15) ? (string)null : dataReader.GetString(15))
                                                    .ReportsTo(dataReader.IsDBNull(16) ? (int?)null : dataReader.GetInt32(16))
                                                    .PhotoPath(dataReader.IsDBNull(17) ? (string)null : dataReader.GetString(17))
                                                    .Build();
                    }
                    dataReader.Close();
                }
                catch (Exception exc)
                {
                    logger.logError(DateTime.Now, "Error while trying to get Employee with EmployeeID = " + employeeID + ".");
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
                logger.logInfo(DateTime.Now, "GetEmployeeById method has sucessfully invoked.");
                return employee;
            }
        }

        public int addEmployee(Employees employee)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.CommandText = "AddEmployee";

            insertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Title", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@TitleOfCourtesy", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime);
            insertCommand.Parameters.Add("@HireDate", SqlDbType.DateTime);
            insertCommand.Parameters.Add("@Address", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@City", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Region", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Country", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Extension", SqlDbType.NVarChar);
            insertCommand.Parameters.Add("@Photo", SqlDbType.Image);
            insertCommand.Parameters.Add("@Notes", SqlDbType.NText);
            insertCommand.Parameters.Add("@ReportsTo", SqlDbType.Int);
            insertCommand.Parameters.Add("@PhotoPath", SqlDbType.NVarChar);

            insertCommand.Parameters["@LastName"].Value = employee.LastName;
            insertCommand.Parameters["@FirstName"].Value = employee.FirstName;
            insertCommand.Parameters["@Title"].Value = employee.Title;
            insertCommand.Parameters["@TitleOfCourtesy"].Value = employee.TitleOfCourtesy;
            insertCommand.Parameters["@BirthDate"].Value = employee.BirthDate;
            insertCommand.Parameters["@HireDate"].Value = employee.HireDate;
            insertCommand.Parameters["@Address"].Value = employee.Address;
            insertCommand.Parameters["@City"].Value = employee.City;
            insertCommand.Parameters["@Region"].Value = employee.Region;
            insertCommand.Parameters["@PostalCode"].Value = employee.PostalCode;
            insertCommand.Parameters["@Country"].Value = employee.Country;
            insertCommand.Parameters["@HomePhone"].Value = employee.HomePhone;
            insertCommand.Parameters["@Extension"].Value = employee.Extension;
            insertCommand.Parameters["@Photo"].Value = employee.Photo;
            insertCommand.Parameters["@Notes"].Value = employee.Notes;
            insertCommand.Parameters["@ReportsTo"].Value = employee.ReportsTo;
            insertCommand.Parameters["@PhotoPath"].Value = employee.PhotoPath;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(insertCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "AddEmployee method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to add new Employee.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateEmployee(Employees employee)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateEmployee";

            updateCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            updateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Title", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@TitleOfCourtesy", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime);
            updateCommand.Parameters.Add("@HireDate", SqlDbType.DateTime);
            updateCommand.Parameters.Add("@Address", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@City", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Region", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Country", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Extension", SqlDbType.NVarChar);
            updateCommand.Parameters.Add("@Photo", SqlDbType.Image);
            updateCommand.Parameters.Add("@Notes", SqlDbType.NText);
            updateCommand.Parameters.Add("@ReportsTo", SqlDbType.Int);
            updateCommand.Parameters.Add("@PhotoPath", SqlDbType.NVarChar);

            updateCommand.Parameters["@EmployeeID"].Value = employee.EmployeeID;
            updateCommand.Parameters["@LastName"].Value = employee.LastName;
            updateCommand.Parameters["@FirstName"].Value = employee.FirstName;
            updateCommand.Parameters["@Title"].Value = employee.Title;
            updateCommand.Parameters["@TitleOfCourtesy"].Value = employee.TitleOfCourtesy;
            updateCommand.Parameters["@BirthDate"].Value = employee.BirthDate;
            updateCommand.Parameters["@HireDate"].Value = employee.HireDate;
            updateCommand.Parameters["@Address"].Value = employee.Address;
            updateCommand.Parameters["@City"].Value = employee.City;
            updateCommand.Parameters["@Region"].Value = employee.Region;
            updateCommand.Parameters["@PostalCode"].Value = employee.PostalCode;
            updateCommand.Parameters["@Country"].Value = employee.Country;
            updateCommand.Parameters["@HomePhone"].Value = employee.HomePhone;
            updateCommand.Parameters["@Extension"].Value = employee.Extension;
            updateCommand.Parameters["@Photo"].Value = employee.Photo;
            updateCommand.Parameters["@Notes"].Value = employee.Notes;
            updateCommand.Parameters["@ReportsTo"].Value = employee.ReportsTo;
            updateCommand.Parameters["@PhotoPath"].Value = employee.PhotoPath;

            int index = 0;
            try
            {
                connection.Open();
                index = Convert.ToInt32(updateCommand.ExecuteScalar());
                logger.logInfo(DateTime.Now, "UpdateEmployee method has sucessfully invoked.");
                return index;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to update Employee.");
                MessageBox.Show(ex.Message);
                return index;
            }
            finally
            {
                connection.Close();
            }
        }

        public int deleteEmployee(int employeeID)
        {
            Connection conn = new Connection();
            SqlConnection connection = conn.SqlConnection;
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteEmployee";

            deleteCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
            deleteCommand.Parameters["@EmployeeID"].Value = employeeID;

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                logger.logInfo(DateTime.Now, "DeleteEmployee method has sucessfully invoked on Employee with EmployeeID = " + employeeID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.logError(DateTime.Now, "Error while trying to delete Employee with EmployeeID = " + employeeID + ".");
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
