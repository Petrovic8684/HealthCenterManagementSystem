using Microsoft.Data.SqlClient;
using Common.Domain;
using System.Transactions;
using System.Data.Common;

namespace DBBroker
{
    public class Broker
    {
        private DBConnection connection;
        public Broker(string connectionString)
        {
            connection = new DBConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Add(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {obj.TableName} ({obj.Columns}) VALUES ({obj.ValuesClause})";

            foreach (var param in obj.GetSqlParameters())
                cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public int AddWithReturnId(IEntity entity)
        {
            using SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"INSERT INTO {entity.TableName} ({entity.Columns}) OUTPUT INSERTED.{entity.PrimaryKey} VALUES ({entity.ValuesClause})";

            foreach (var param in entity.GetSqlParameters())
                cmd.Parameters.Add(param);

            int id = (int)cmd.ExecuteScalar();
            cmd.Dispose();

            return id;
        }

        public void Update(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.SetClause} WHERE {obj.PrimaryKeyCondition}";

            foreach (var param in obj.GetSqlParameters())
                cmd.Parameters.Add(param);

            foreach (var param in obj.GetPrimaryKeyParameters())
                if (!cmd.Parameters.Contains(param.ParameterName))
                    cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {obj.PrimaryKeyCondition}";

            foreach (var param in obj.GetPrimaryKeyParameters())
                cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName}";
            using SqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();
            return entity.GetReaderList(reader);
        }

        public List<IEntity> GetByCondition(IEntity entity)
        {
            using SqlCommand cmd = connection.CreateCommand();

            var (whereClause, parameters) = entity.GetWhereClauseWithParameters();

            string tableName = !string.IsNullOrEmpty(entity.JoinTableName)
                ? entity.JoinTableName
                : entity.TableName;

            string selectClause = entity.SelectClause ?? "*";

            cmd.CommandText = $"SELECT {selectClause} FROM {tableName} WHERE {whereClause}";

            foreach (var param in parameters)
                cmd.Parameters.Add(param);

            using SqlDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();

            return entity.GetReaderList(reader);
        }

        public int GetFirstId(IEntity entity)
        {
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT TOP 1 {entity.PrimaryKey} FROM {entity.TableName}";

            object result = cmd.ExecuteScalar();

            cmd.Dispose();

            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);

            return -1;
        }
    }
}
