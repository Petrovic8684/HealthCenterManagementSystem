using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class StavkaZdravstvenogKartona : IEntity
    {
        public int RedniBroj { get; set; }
        public DateTime DatumUpisa { get; set; }
        public Double Ponder { get; set; }
        public Double Skor {  get; set; }
        public ZdravstveniKarton ZdravstveniKarton {  get; set; }
        public Dijagnoza Dijagnoza { get; set; }

        public string TableName => "stavkaZdravstvenogKartona";
        public string Values =>
            $"{(ZdravstveniKarton != null ? ZdravstveniKarton.Id : "NULL")}, " +
            $"'{DatumUpisa:yyyy-MM-dd HH:mm:ss}', {Ponder}, 0, " +
            $"{(Dijagnoza != null ? Dijagnoza.Id : "NULL")}";
        public string SetClause =>
            $"idZdravstveniKarton = {(ZdravstveniKarton != null ? ZdravstveniKarton.Id : "NULL")}, " +
            $"datumUpisa = '{DatumUpisa:yyyy-MM-dd HH:mm:ss}', " +
            $"ponder = {Ponder}, " +
            $"idDijagnoza = {(Dijagnoza != null ? Dijagnoza.Id : "NULL")}";
        public string PrimaryKey => $"idZdravstveniKarton, rb";
        public string PrimaryKeyCondition => $"idZdravstveniKarton = {ZdravstveniKarton.Id} AND rb = {RedniBroj}";
        public string Prikaz => $"{Dijagnoza.Naziv} | {Ponder}";
        public string Criteria { get; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavkeZdravstvenogKartona = new List<IEntity>();
            while (reader.Read())
            {
                StavkaZdravstvenogKartona stavkaZdravstvenogKartona = new StavkaZdravstvenogKartona
                {
                    ZdravstveniKarton = new ZdravstveniKarton
                    {
                        Id = (int)reader["idZdravstveniKarton"],
                    },
                    RedniBroj = (int)reader["rb"],
                    DatumUpisa = (DateTime)reader["datumUpisa"],
                    Ponder = Convert.ToDouble(reader["ponder"]),
                    Skor = Convert.ToDouble(reader["skor"]),
                    Dijagnoza = new Dijagnoza
                    {
                        Id = (int)reader["idDijagnoza"]
                    }
                };
                stavkeZdravstvenogKartona.Add(stavkaZdravstvenogKartona);
            }
            return stavkeZdravstvenogKartona;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}