using System.Data.SqlClient;

namespace BussinesService
{
    sealed class Connection
    {
        private const string connStringNorthwind = @"Data Source = .\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security = True";
        private SqlConnection sqlConnection = new SqlConnection(connStringNorthwind);
        private static Connection instance = null;

        public static Connection Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Connection();
                }
                return instance;
            }
        }

        public SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }
        }
    }
}
