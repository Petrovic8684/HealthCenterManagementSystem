using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace Common.Domain
{
    public class LeS : IEntity
    {
        public int IdLekar { get; set; }
        public int IdSertifikat { get; set; }
        public DateTime DatumIzdavanja { get; set; }

        public string TableName => "les";

        public string Columns => "idLekar, idSertifikat, datumIzdavanja";

        public string ValuesClause => "@IdLekar, @IdSertifikat, @DatumIzdavanja";

        public string SetClause => "datumIzdavanja = @DatumIzdavanja";

        public string PrimaryKey => "idLekar AND idSertifikat";

        public string PrimaryKeyCondition => "idLekar = @IdLekar AND idSertifikat = @IdSertifikat";

        public string Prikaz => DatumIzdavanja.ToShortDateString();

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (IdLekar > 0)
            {
                conditions.Add("idLekar = @IdLekar");
                parameters.Add(new SqlParameter("@IdLekar", IdLekar));
            }

            if (IdSertifikat > 0)
            {
                conditions.Add("idSertifikat = @IdSertifikat");
                parameters.Add(new SqlParameter("@IdSertifikat", IdSertifikat));
            }

            string whereClause = conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1";

            return (whereClause, parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new LeS
                {
                    IdLekar = (int)reader["idLekar"],
                    IdSertifikat = (int)reader["idSertifikat"],
                    DatumIzdavanja = (DateTime)reader["datumIzdavanja"],
                });
            }
            return lista;
        }

        public List<SqlParameter> GetSqlParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdLekar", IdLekar),
                new SqlParameter("@IdSertifikat", IdSertifikat),
                new SqlParameter("@DatumIzdavanja", DatumIzdavanja),
            };
        }

        public List<SqlParameter> GetPrimaryKeyParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@IdLekar", IdLekar),
                new SqlParameter("@IdSertifikat", IdSertifikat)
            };
        }

        public override string ToString() => Prikaz;
    }
}
