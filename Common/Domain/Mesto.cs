using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Mesto : ICrudEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public string TableName => "mesto";
        public string ClassNameAccusativeSingular => "mesto";
        public string ClassNameAccusativePlural => "mesta";

        public string Columns => "naziv, postanskiBroj";

        public string ValuesClause => "@Naziv, @PostanskiBroj";

        public string SetClause => "naziv = @Naziv, postanskiBroj = @PostanskiBroj";

        public string PrimaryKey => "idMesto";

        public string PrimaryKeyCondition => "idMesto = @Id";

        public string DisplayValue => $"{Naziv}";

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (Id > 0)
            {
                conditions.Add("idMesto = @Id");
                parameters.Add(new SqlParameter("@Id", Id));
            }

            if (!string.IsNullOrWhiteSpace(Naziv))
            {
                conditions.Add("naziv LIKE @Naziv");
                parameters.Add(new SqlParameter("@Naziv", $"%{Naziv}%"));
            }

            if (!string.IsNullOrWhiteSpace(PostanskiBroj))
            {
                conditions.Add("postanskiBroj LIKE @PostanskiBroj");
                parameters.Add(new SqlParameter("@PostanskiBroj", $"%{PostanskiBroj}%"));
            }

            return (conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1", parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Mesto
                {
                    Id = (int)reader["idMesto"],
                    Naziv = (string)reader["naziv"],
                    PostanskiBroj = (string)reader["postanskiBroj"],
                });
            }
            return lista;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Naziv", Naziv),
                new SqlParameter("@PostanskiBroj", PostanskiBroj),
            };
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
        }

        public override string ToString() => DisplayValue;
    }
}
