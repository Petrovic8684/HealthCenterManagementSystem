using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Lekar : ICrudEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Sifra { get; set; }
        public List<Sertifikat> Sertifikati { get; set; }

        public string TableName => "lekar";
        public string Values => $"'{Ime}', '{Prezime}', '{Email}', '{Sifra}'";
        public string SetClause => $"ime = '{Ime}', prezime = '{Prezime}', email = '{Email}', sifra = '{Sifra}'";
        public string PrimaryKey => $"idLekar";
        public string PrimaryKeyCondition => $"idLekar = {Id}";
        public string Prikaz => $"{Ime} {Prezime}";

        public string Criteria
        {
            get
            {
                var criteria = new List<string>();

                if (!string.IsNullOrWhiteSpace(Ime))
                    criteria.Add($"ime LIKE '%{Ime}%'");

                if (!string.IsNullOrWhiteSpace(Prezime))
                    criteria.Add($"prezime LIKE '%{Prezime}%'");

                if (Sertifikati?.Count > 0)
                    criteria.Add($"idLekar IN (SELECT idLekar FROM LeS WHERE idSertifikat = {Sertifikati[0]?.Id})");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lekari = new List<IEntity>();
            while (reader.Read())
            {
                Lekar lekar = new Lekar
                {
                    Id = (int)reader["idLekar"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Email = (string)reader["email"],
                    Sifra = (string)reader["sifra"],
                };
                lekari.Add(lekar);
            }
            return lekari;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}