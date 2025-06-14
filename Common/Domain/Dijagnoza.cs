using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Dijagnoza : ICrudEntity
    {
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public string Opis { get; set; }
        public Double BazniSkor {  get; set; }

        public string TableName => "dijagnoza";

        public string Columns => "naziv, opis, bazniSkor";

        public string ValuesClause => "@Naziv, @Opis, @BazniSkor";

        public string SetClause => "naziv = @Naziv, opis = @Opis, bazniSkor = @BazniSkor";

        public string PrimaryKey => "idDijagnoza";

        public string PrimaryKeyCondition => "idDijagnoza = @Id";

        public string Prikaz => Naziv;

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(Naziv))
            {
                conditions.Add("naziv LIKE @Naziv");
                parameters.Add(new SqlParameter("@Naziv", $"%{Naziv}%"));
            }

            if (!string.IsNullOrWhiteSpace(Opis))
            {
                conditions.Add("opis LIKE @Opis");
                parameters.Add(new SqlParameter("@Opis", $"%{Opis}%"));
            }

            return (conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1", parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Dijagnoza
                {
                    Id = (int)reader["idDijagnoza"],
                    Naziv = (string)reader["naziv"],
                    Opis = (string)reader["opis"],
                    BazniSkor = (double)(reader["bazniSkor"])
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
                new SqlParameter("@Opis", Opis),
                new SqlParameter("@BazniSkor", BazniSkor)
            };
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
        }

        public override string ToString() => Prikaz;
    }
}
