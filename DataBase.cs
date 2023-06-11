using System.Data.SqlClient;

namespace DemSecond
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GrEI3uI3JI9I;Initial Catalog=Dem;Integrated Security=True");

        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
