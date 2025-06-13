using Microsoft.Data.SqlClient;

public interface IEntity
{
    string TableName { get; }
    string Values { get; }                
    string SetClause { get; }
    string PrimaryKey { get; }
    string PrimaryKeyCondition { get; }
    string Prikaz { get; }
    List<IEntity> GetReaderList(SqlDataReader reader);
}
