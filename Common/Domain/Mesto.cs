using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Mesto : ICrudEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public string TableName => "mesto";
        public string Values => $"'{Naziv}', '{PostanskiBroj}'";
        public string SetClause => $"naziv = '{Naziv}', postanskiBroj = '{PostanskiBroj}'";
        public string PrimaryKey => $"idMesto";
        public string PrimaryKeyCondition => $"idMesto = {Id}";
        public string Prikaz => $"{Naziv}";

        public string Criteria
        {
            get
            {
                var criteria = new List<string>();

                if (!string.IsNullOrWhiteSpace(Naziv))
                    criteria.Add($"naziv LIKE '%{Naziv}%'");

                if (!string.IsNullOrWhiteSpace(PostanskiBroj))
                    criteria.Add($"postanskiBroj LIKE '%{PostanskiBroj}%'");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> mesta = new List<IEntity>();
            while (reader.Read())
            {
                Mesto mesto= new Mesto
                {
                    Id = (int)reader["idMesto"],
                    Naziv = (string)reader["naziv"],
                    PostanskiBroj = (string)reader["postanskiBroj"]
                };
                mesta.Add(mesto);
            }
            return mesta;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}
