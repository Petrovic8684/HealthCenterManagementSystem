using Microsoft.Data.SqlClient;
using System.Collections.Generic;

public interface IEntity
{
    string TableName { get; }
    string Columns { get; }
    string ValuesClause { get; }
    string SetClause { get; }
    public string PrimaryKey { get; }
    string PrimaryKeyCondition { get; }
    string? JoinTableName => null;
    string? SelectClause => null;
    string Prikaz { get; }
    (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters();

    List<IEntity> GetReaderList(SqlDataReader reader);
    List<SqlParameter> GetSqlParameters();
    List<SqlParameter> GetPrimaryKeyParameters();
}

public interface ICrudEntity : IEntity
{
    int Id { get; set; }
}
