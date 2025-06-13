using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class ZdravstveniKarton : IEntity
    {
        public int Id { get; set; }
        public DateTime? DatumOtvaranja { get; set; }
        public string Napomena { get; set; }
        public Double UkupniSkor { get; set; }
        public string Stanje {  get; set; }
        public Lekar Lekar { get; set; }
        public Pacijent Pacijent { get; set; }
        public List<StavkaZdravstvenogKartona> Stavke { get; set; }

        public string TableName => "zdravstveniKarton";
        public string Values =>
            $"'{DatumOtvaranja}', '{Napomena}', 0, 'Zdrav', {(Lekar != null ? Lekar.Id : "NULL")}, {(Pacijent != null ? Pacijent.Id : "NULL")}";
        public string SetClause =>
            $"datumOtvaranja = '{DatumOtvaranja}', napomena = '{Napomena}', idLekar = {(Lekar != null ? Lekar.Id : "NULL")}, idPacijent = {(Pacijent != null ? Pacijent.Id : "NULL")}";

        public string PrimaryKey => $"idZdravstveniKarton";

        public string PrimaryKeyCondition => $"idZdravstveniKarton = {Id}";
        public string Prikaz => $"{DatumOtvaranja}";

        public ZdravstveniKarton()
        {
            DatumOtvaranja = null;
            Lekar = new Lekar();
            Pacijent = new Pacijent();
        }

        public string Criteria
        {
            get
            {
                var criteria = new List<string>();

                if (DatumOtvaranja != null)
                    criteria.Add($"CAST(datumOtvaranja AS DATE) >= '{DatumOtvaranja:yyyy-MM-dd}'");

                if (!string.IsNullOrWhiteSpace(Lekar?.Ime))
                    criteria.Add($"idLekar IN (SELECT idLekar FROM lekar WHERE ime LIKE '%{Lekar.Ime}%')");

                if (!string.IsNullOrWhiteSpace(Pacijent?.Ime))
                    criteria.Add($"idPacijent IN (SELECT idPacijent FROM pacijent WHERE ime LIKE '%{Pacijent.Ime}%')");

                if (Stavke != null && Stavke.Count > 0 && !string.IsNullOrWhiteSpace(Stavke[0].Dijagnoza?.Naziv))
                    criteria.Add($@"
                idZdravstveniKarton IN (
                    SELECT idZdravstveniKarton
                    FROM stavkaZdravstvenogKartona
                    WHERE idDijagnoza IN (
                        SELECT idDijagnoza FROM dijagnoza WHERE naziv LIKE '%{Stavke[0].Dijagnoza.Naziv}%'
                    )
                )");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zdravstveniKartoni = new List<IEntity>();
            while (reader.Read())
            {
                ZdravstveniKarton zdravstveniKarton = new ZdravstveniKarton
                {
                    Id = (int)reader["idZdravstveniKarton"],
                    DatumOtvaranja = (DateTime)reader["datumOtvaranja"],
                    Napomena = (string)reader["napomena"],
                    UkupniSkor = Convert.ToDouble(reader["ukupniSkor"]),
                    Stanje = (string)reader["stanje"],

                    Lekar = new Lekar
                    {
                        Id = (int)reader["idLekar"]
                    },
                    Pacijent = new Pacijent
                    {
                        Id = (int)reader["idPacijent"]
                    }
                };
                zdravstveniKartoni.Add(zdravstveniKarton);
            }
            return zdravstveniKartoni;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}