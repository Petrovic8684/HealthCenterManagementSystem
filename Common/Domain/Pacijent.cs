using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Pacijent : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public Mesto Mesto { get; set; }

        public string TableName => "pacijent";
        public string Values => $"'{Ime}', '{Prezime}', '{Email}', {(Mesto != null ? Mesto.Id : "NULL")}";

        public string SetClause =>
            $"ime = '{Ime}', prezime = '{Prezime}', email = '{Email}', idMesto = {(Mesto != null ? Mesto.Id : "NULL")}";

        public string PrimaryKey => $"idPacijent";
        public string PrimaryKeyCondition => $"idPacijent = {Id}";
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

                if (Mesto != null)
                    criteria.Add($"idMesto = {Mesto.Id}");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> pacijenti = new List<IEntity>();
            while (reader.Read())
            {
                Pacijent pacijent = new Pacijent
                {
                    Id = (int)reader["idPacijent"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Email = (string)reader["email"],

                    Mesto = new Mesto
                    {
                        Id = (int)reader["idMesto"],
                    }
                };
                pacijenti.Add(pacijent);
            }
            return pacijenti;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}