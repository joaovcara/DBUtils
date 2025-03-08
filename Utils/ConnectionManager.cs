using Microsoft.Data.SqlClient;

namespace DBUtils.Utils
{
    public static class ConnectionManager
    {
        private static SqlConnection _connection;
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqlConnection GetConnection()
        {
            if (!CheckConnection(_connection))
            {
                if (string.IsNullOrEmpty(_connectionString))
                    throw new InvalidOperationException("String de conexão não foi configurada.");

                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        public static void CloseConnection()
        {
            if (CheckConnection(_connection))
            {
                _connection.Close();
            }
        }

        public static bool CheckConnection(SqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            return false;
        }
    }
}

