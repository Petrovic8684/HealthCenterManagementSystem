using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Sertifikat : ICrudEntity
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        public string TableName => "sertifikat";
        public string ImeKlaseAkuzativJednine => "sertifikat";
        public string ImeKlaseAkuzativMnozine => "sertifikate";

        public string Columns => "opis";

        public string ValuesClause => "@Opis";

        public string SetClause => "opis = @Opis";

        public string PrimaryKey => "idSertifikat";

        public string PrimaryKeyCondition => "idSertifikat = @Id";

        public string Prikaz => Opis;

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

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
                lista.Add(new Sertifikat
                {
                    Id = (int)reader["idSertifikat"],
                    Opis = (string)reader["opis"]
                });
            }
            return lista;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Opis", Opis)
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
