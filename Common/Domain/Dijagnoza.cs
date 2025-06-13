using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Dijagnoza : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double BazniSkor { get; set; }

        public string TableName => "dijagnoza";
        public string Values => $"'{Naziv}', '{Opis}', '{BazniSkor}'";
        public string SetClause => $"naziv = '{Naziv}', opis = '{Opis}', bazniSkor = '{BazniSkor}'";
        public string PrimaryKey => $"idDijagnoza";
        public string PrimaryKeyCondition => $"idDijagnoza = {Id}";
        public string Prikaz => $"{Naziv}";

        public string Criteria
        {
            get
            {
                var criteria = new List<string>();

                if (!string.IsNullOrWhiteSpace(Naziv))
                    criteria.Add($"naziv LIKE '%{Naziv}%'");

                if (!string.IsNullOrWhiteSpace(Opis))
                    criteria.Add($"opis LIKE '%{Opis}%'");

                return criteria.Count > 0 ? string.Join(" AND ", criteria) : "1=1";
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> dijagnoze = new List<IEntity>();
            while (reader.Read())
            {
                Dijagnoza dijagnoza = new Dijagnoza
                {
                    Id = (int)reader["idDijagnoza"],
                    Naziv = (string)reader["naziv"],
                    Opis = (string)reader["opis"],
                    BazniSkor = (double)reader["bazniSkor"],
                };
                dijagnoze.Add(dijagnoza);
            }
            return dijagnoze;
        }

        public override string ToString()
        {
            return $"{Prikaz}";
        }
    }
}