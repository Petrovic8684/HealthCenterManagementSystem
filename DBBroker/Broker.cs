using Microsoft.Data.SqlClient;
using Common.Domain;
using System.Transactions;
using System.Data.Common;

namespace DBBroker
{
    public class Broker
    {
        private DBConnection connection;
        public Broker()
        {
            connection = new DBConnection();
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
            cmd.CommandText = $"INSERT INTO {obj.TableName} VALUES({obj.Values} )";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Update(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.SetClause} WHERE {obj.PrimaryKeyCondition}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {obj.PrimaryKeyCondition}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {condition}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public int AddWithReturnId(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} OUTPUT INSERTED.{entity.PrimaryKey} VALUES ({entity.Values})";

            int id = (int)cmd.ExecuteScalar();
            cmd.Dispose();

            return id;
        }

    }
}
