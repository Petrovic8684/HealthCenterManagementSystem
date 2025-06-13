using Microsoft.Data.SqlClient;

public interface IEntity
{
    string TableName { get; }
    string Values { get; }                
    string SetClause { get; }
    string PrimaryKey { get; }
    string PrimaryKeyCondition { get; }
    string Prikaz { get; }
    string Criteria { get; }
    List<IEntity> GetReaderList(SqlDataReader reader);
}

public interface ICrudEntity : IEntity
{
    int Id { get; set; }
}