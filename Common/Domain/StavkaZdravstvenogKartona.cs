using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public class StavkaZdravstvenogKartona : IEntity
    {
        public int RedniBroj { get; set; }
        public ZdravstveniKarton ZdravstveniKarton { get; set; } = new();
        public DateTime DatumUpisa { get; set; }
        public double Ponder { get; set; }
        public double Skor { get; set; }
        public Dijagnoza Dijagnoza { get; set; } = new();

        public string TableName => "StavkaZdravstvenogKartona";
        public string Columns => "idZdravstveniKarton, datumUpisa, ponder, idDijagnoza";
        public string ValuesClause => "@IdZdravstveniKarton, @DatumUpisa, @Ponder, @IdDijagnoza";
        public string SetClause => "datumUpisa=@DatumUpisa, ponder=@Ponder, idDijagnoza=@IdDijagnoza";
        public string PrimaryKey => "idZdravstveniKarton, rb";
        public string PrimaryKeyCondition => "idZdravstveniKarton = @IdZdravstveniKarton AND rb = @RedniBroj";
        public string Prikaz => $"{Dijagnoza?.Naziv} | {Ponder}";

        public (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters()
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (ZdravstveniKarton != null && ZdravstveniKarton.Id > 0)
            {
                conditions.Add("idZdravstveniKarton IN (SELECT idZdravstveniKarton FROM ZdravstveniKarton WHERE idZdravstveniKarton = @IdZdravstveniKarton)");
                parameters.Add(new SqlParameter("@IdZdravstveniKarton", ZdravstveniKarton.Id));
            }

            string whereClause = conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1";
            return (whereClause, parameters);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new StavkaZdravstvenogKartona
                {
                    RedniBroj = (int)reader["rb"],
                    ZdravstveniKarton = new ZdravstveniKarton { Id = (int)reader["idZdravstveniKarton"] },
                    DatumUpisa = (DateTime)reader["datumUpisa"],
                    Ponder = (double)reader["ponder"],
                    Skor = (double)reader["skor"],
                    Dijagnoza = new Dijagnoza { Id = (int)reader["idDijagnoza"] }
                });
            }
            return lista;
        }

        public List<SqlParameter> GetSqlParameters() => new()
        {
            new SqlParameter("@RedniBroj", RedniBroj),
            new SqlParameter("@IdZdravstveniKarton", ZdravstveniKarton.Id),
            new SqlParameter("@DatumUpisa", DatumUpisa),
            new SqlParameter("@Ponder", Ponder),
            new SqlParameter("@IdDijagnoza", Dijagnoza.Id),
        };

        public List<SqlParameter> GetPrimaryKeyParameters() => new()
        {
            new SqlParameter("@IdZdravstveniKarton", ZdravstveniKarton.Id),
            new SqlParameter("@RedniBroj", RedniBroj)
        };

        public override string ToString() => Prikaz;
    }
}
