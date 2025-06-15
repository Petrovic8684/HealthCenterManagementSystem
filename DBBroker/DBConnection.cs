using Microsoft.Data.SqlClient;

namespace DBBroker
{
    public class DBConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DBConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection?.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction?.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
